using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using PathFinderDijkstra.Grid;


namespace PathFinderDijkstra
{
    public partial class Form1 : Form
    {
        public const int INFINITY = 99999;

        private GridDrawer.GridDrawer gridDrawer;
        private CellType clickType = CellType.Empty;


        private string fileContent = string.Empty;
        private string filePath = string.Empty;

        private Stopwatch watch;

        ExternalProxy asmProxy;
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();

            watch = new System.Diagnostics.Stopwatch();

            var numHeight = gridDrawer.VerticalCells;
            var numWidth = gridDrawer.HorizontalCells;

            numHeightSel.Value = numHeight;
            numWidthSel.Value = numWidth;

            clickType = CellType.Solid;

            languageComboBox.SelectedIndex = 0;

            asmProxy = new ExternalProxy();

            int number_of_nodes = 2;
            int[,] g = new int[,] { { 1, 1 } };
            int[,] cost = new int[number_of_nodes, number_of_nodes];
            int[] distance = new int[number_of_nodes];
            int[] predecessor = new int[number_of_nodes];
            int[] visitedVertices = new int[number_of_nodes];


            try
            {
                printLog($"Testing DLL file");
                asmProxy.executeDijkstraAsm(g, number_of_nodes, 0, cost, distance, predecessor, visitedVertices);

                printLog($"Assembly DLL file loaded successfully");

            }
            catch (Exception e)
            {
                printLog($"Unable to load assembly DLL");
                printLog($"{e.StackTrace}");
            }

            try
            {
                printLog($"Testing C++ file");
                asmProxy.executeDijkstraC(g, number_of_nodes, 0, cost, distance, predecessor, visitedVertices);

                printLog($"C++ DLL file loaded successfully");

            }
            catch (Exception e)
            {
                printLog($"Unable to load C++ DLL");
                printLog($"{e.StackTrace}");
            }


        }

        private void InitializeGrid()
        {
            gridDrawer = new GridDrawer.GridDrawer(mainGrid);
            gridDrawer.Draw();
        }

        private void InitializeGrid(int verticalCells, int horizontalCells)
        {
            gridDrawer = new GridDrawer.GridDrawer(mainGrid, verticalCells, horizontalCells);
            gridDrawer.Draw();
        }


        private void printLog(string text)
        {
            logsTextBox.AppendText($"{DateTime.Now.ToString("HH:mm:ss.fff")}: {text} \n");

            logsTextBox.SelectionStart = logsTextBox.Text.Length;
            logsTextBox.ScrollToCaret();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete the entire map?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                gridDrawer.Reset();
            }


        }

        private void mainGrid_MouseClick(object sender, MouseEventArgs e)
        {

            int xCell = e.X / (int)gridDrawer.GetCellSize().X;
            int yCell = e.Y / (int)gridDrawer.GetCellSize().Y;

            Console.WriteLine($"Current Point id: {yCell * gridDrawer.HorizontalCells + xCell}");

            gridDrawer.gridClicked(e.X, e.Y, clickType);
        }

        private void printGraph(int[,] g, int number_of_nodes)
        {
            for (var y = 0; y < number_of_nodes; y++)
            {

                Console.Write("{");

                for (var x = 0; x < number_of_nodes; x++)
                {

                    Console.Write($" {(int)g[x, y]}");

                    if (x < number_of_nodes - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("}");

                if (y < number_of_nodes - 1)
                {
                    Console.Write(",");
                }

                Console.Write("\n");

            }
            Console.Write("}");
        }

        private int[,] convertGridToGraph(Cell[,] grid)
        {

            var width = gridDrawer.Grid.CellObjects.GetLength(0);
            var height = gridDrawer.Grid.CellObjects.GetLength(1);

            int number_of_nodes = height * width;

            int[,] graph = new int[number_of_nodes, number_of_nodes];

            var node_id = 0;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (width > x + 1 && grid[x + 1, y].type != 0 && grid[x, y].type != 0)
                    {
                        graph[node_id + 1, node_id] = 1;
                        graph[node_id, node_id + 1] = 1;
                    }

                    if (height > y + 1 && grid[x, y + 1].type != 0 && grid[x, y].type != 0)
                    {
                        graph[node_id + width, node_id] = 1;
                        graph[node_id, node_id + width] = 1;

                    }
                    node_id++;
                }
            }
            return graph;
        }


        private void runAlgoButton_Click(object sender, EventArgs e)
        {

            if (languageComboBox.SelectedItem == null)
            {
                MessageBox.Show("No selected algorithm", "Select algorithm", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (gridDrawer.startCell == null || gridDrawer.startCell.type != CellType.A)
            {
                MessageBox.Show("There is no starting point selected", "Select start point", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (gridDrawer.endCell == null || gridDrawer.endCell.type != CellType.B)
            {
                MessageBox.Show("There is no target point selected", "Select target point", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            var width = gridDrawer.Grid.CellObjects.GetLength(0);
            var height = gridDrawer.Grid.CellObjects.GetLength(1);


            int number_of_nodes = height * width;


            printLog($"Converting Maze to Graph");

            int[,] graph = convertGridToGraph(gridDrawer.Grid.CellObjects);


            int startNode = gridDrawer.startCell.coords.y * gridDrawer.HorizontalCells + gridDrawer.startCell.coords.x;
            int endNode = gridDrawer.endCell.coords.y * gridDrawer.HorizontalCells + gridDrawer.endCell.coords.x;


            int[,] cost = new int[number_of_nodes, number_of_nodes];
            int[] distance = new int[number_of_nodes];
            int[] predecessor = new int[number_of_nodes];
            int[] visitedVertices = new int[number_of_nodes];


            int result;

            clearSolBtn_Click(null, null);

            printLog($"Run the algorithm: {languageComboBox.SelectedItem.ToString()}");

            watch.Reset();
            watch.Start();

            if (languageComboBox.SelectedIndex == 0)
            {
                result = asmProxy.executeDijkstraAsm(graph, number_of_nodes, startNode, cost, distance, predecessor, visitedVertices);
            }
            else
            {
                result = asmProxy.executeDijkstraC(graph, number_of_nodes, startNode, cost, distance, predecessor, visitedVertices);
            }

            watch.Stop();

            printLog($"Execution Time: {watch.ElapsedMilliseconds} ms");

            watch.Reset();

            if (endNode != startNode)
            {
                var colStartNode = (startNode / width) + 1;
                var rowStartNode = (startNode % width) + 1;

                var colEndNode = (endNode / width) + 1;
                var rowEndNode = (endNode % width) + 1;

                if (distance[endNode] != INFINITY)
                {
                    printLog($"Distance form start node: {startNode} ({rowStartNode}, {colStartNode}) to target node: {endNode} ({rowEndNode}, {colEndNode}) is equal {distance[endNode]}");
                }
                else
                {
                    printLog($"There is no path between the selected points");
                }

                var j = endNode;
                do
                {
                    j = predecessor[j];
                    var col = (j / width);
                    var row = (j % width);
                    if (j != startNode)
                        gridDrawer.setCellWithoutUpdate(row, col, CellType.Path);

                } while (j != startNode);
                gridDrawer.Draw();
            }
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();

                        int[,] values = JsonConvert.DeserializeObject<int[,]>(fileContent);

                        var rows = values.GetLength(0);
                        var cols = values.GetLength(1);

                        numHeightSel.Value = rows;
                        numWidthSel.Value = cols;

                        InitializeGrid(cols, rows);

                        printLog($"External file loaded successfully, path: {openFileDialog.FileName}, width: {cols} heigth: {rows}");

                        for (var y = 0; y < cols; y++)
                        {
                            for (var x = 0; x < rows; x++)
                            {

                                gridDrawer.setCellWithoutUpdate(y, x, (CellType)values[x, y]);
                            }
                        }
                        gridDrawer.Draw();
                    }
                }
            }
        }

        private void saveDataBtn_Click(object sender, EventArgs e)
        {


            Cell[,] grid = gridDrawer.Grid.CellObjects;

            var width = grid.GetLength(0);
            var height = grid.GetLength(1);

            int[,] exportArray = new int[height, width];

            for (var y = 0; y < height; y++)
            {

                for (var x = 0; x < width; x++)
                {
                    exportArray[y, x] = (int)grid[x, y].type;

                }
            }


            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Maze.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                clearSolBtn_Click(null, null);
                string json = JsonConvert.SerializeObject(exportArray, Formatting.Indented);

                StreamWriter writer = new StreamWriter(save.OpenFile());

                writer.WriteLine(json);
                writer.Dispose();
                writer.Close();

            }

            printLog($"File exported successfully, path: {save.FileName}");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cell[,] grid = gridDrawer.Grid.CellObjects;

            var width = grid.GetLength(0);
            var height = grid.GetLength(1);
            int number_of_nodes = height * width;

            int[,] graph = new int[number_of_nodes, number_of_nodes];


            var node_id = 0;

            for (var y = 0; y < height; y++)
            {

                for (var x = 0; x < width; x++)
                {

                    if (width > x + 1 && grid[x + 1, y].type != 0 && grid[x, y].type != 0)
                    {
                        graph[node_id + 1, node_id] = 1;
                        graph[node_id, node_id + 1] = 1;
                    }

                    if (height > y + 1 && grid[x, y + 1].type != 0 && grid[x, y].type != 0)
                    {
                        graph[node_id + width, node_id] = 1;
                        graph[node_id, node_id + width] = 1;

                    }

                    node_id++;
                }
            }

            printGraph(graph, number_of_nodes);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            logsTextBox.Text = "";
        }

        private void mazeDimChange_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete the entire map?",
                         "Confirm Delete",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                InitializeGrid((int)numWidthSel.Value, (int)numHeightSel.Value);
            }
        }

        private void clearSolBtn_Click(object sender, EventArgs e)
        {

            Cell[,] grid = gridDrawer.Grid.CellObjects;

            var width = grid.GetLength(0);
            var height = grid.GetLength(1);

            for (var y = 0; y < height; y++)
            {

                for (var x = 0; x < width; x++)
                {
                    if (grid[x, y].type == CellType.Path)
                    {
                        gridDrawer.setCellWithoutUpdate(x, y, CellType.Empty);
                    }

                }
            }
            gridDrawer.Draw();

        }

        private void wallRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            clickType = CellType.Solid;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            clickType = CellType.Empty;
        }

        private void startRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            clickType = CellType.A;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            clickType = CellType.B;
        }

        private void exportLog_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Logs.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                writer.WriteLine(logsTextBox.Text);
                writer.Dispose();
                writer.Close();

            }

            printLog($"Log file exported successfully, path: {save.FileName}");
        }
    }
}
