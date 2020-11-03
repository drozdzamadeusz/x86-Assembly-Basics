#include<stdio.h>
#include<conio.h>
#include <iostream>

#include <chrono>

#include "Data.h"

#define INFINITY_C 9999
#define MAX 10
//#define MAX 4





						//       8					12				16			20				24			28			32
extern "C" int DijkstraASM(int* graph, int number_of_vertices, int startnode, int* cost, int* distance, int* pred, int* visited);


void dijkstra(int * graph, int number_of_vertices, int startnode, int * cost, int * distance, int * pred, int * visited)
{

	//int cost[V][V], distance[V], pred[V];

	int count, mindistance, nextnode, i, j;

	//pred[] stores the predecessor of each node
	//count gives the number of nodes seen so far
	//create the cost matrix
	for (i = 0; i < number_of_vertices; i++) {
		for (j = 0; j < number_of_vertices; j++) {

			int k = i * number_of_vertices + j;

			if (graph[k] == 0){
				cost[k] = INFINITY_C;
			}else {
				cost[k] = graph[k];
			}
		}
	}

	//initialize pred[], distance[] and visited[]
	for (i = 0; i < number_of_vertices; i++)
	{
		int k = startnode * number_of_vertices + i;

		distance[i] = cost[k];
		pred[i] = startnode;
		visited[i] = 0;
	}

	distance[startnode] = 0;
	visited[startnode] = 1;
	count = 2;

	while (count < number_of_vertices )
	{
		mindistance = INFINITY_C;

		//nextnode gives the node at minimum distance
		for (i = 0; i < number_of_vertices; i++)
			if (distance[i] < mindistance && !visited[i])
			{
				mindistance = distance[i];
				nextnode = i;
			}

		//check if a better path exists through nextnode			
		visited[nextnode] = 1;

		for (i = 0; i < number_of_vertices; i++)
			if (!visited[i]) {

				int k = nextnode * number_of_vertices + i;

				if (mindistance + cost[k] < distance[i])
				{
					distance[i] = mindistance + cost[k];
					pred[i] = nextnode;
				}
			}
		count++;
	}


}


void dijkstra_old(int G[MAX][MAX], int n, int startnode)
{

	int cost[MAX][MAX], distance[MAX], pred[MAX];
	int visited[MAX], count, mindistance, nextnode, i, j;

	//pred[] stores the predecessor of each node
	//count gives the number of nodes seen so far
	//create the cost matrix
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++)
			if (G[i][j] == 0)
				cost[i][j] = INFINITY;
			else
				cost[i][j] = G[i][j];

	//initialize pred[],distance[] and visited[]
	for (i = 0; i < n; i++)
	{
		distance[i] = cost[startnode][i];
		pred[i] = startnode;
		visited[i] = 0;
	}

	distance[startnode] = 0;
	visited[startnode] = 1;
	count = 1;

	while (count < n - 1)
	{
		mindistance = INFINITY;

		//nextnode gives the node at minimum distance
		for (i = 0; i < n; i++)
			if (distance[i] < mindistance)
				if(!visited[i])
				{
					mindistance = distance[i];
					nextnode = i;
				}

		//check if a better path exists through nextnode			
		visited[nextnode] = 1;
		for (i = 0; i < n; i++)
			if (!visited[i])
				if (mindistance + cost[nextnode][i] < distance[i])
				{
					distance[i] = mindistance + cost[nextnode][i];
					pred[i] = nextnode;
				}
		count++;
	}

	//print the path and distance of each node
	/*for (i = 0; i < n; i++)
		if (i != startnode)
		{
			printf("\nDistance of node%d=%d", i, distance[i]);
			printf("\nPath=%d", i);

			j = i;
			do
			{
				j = pred[j];
				printf("<-%d", j);
			} while (j != startnode);
		}*/
}

int main()
{

	//int const number_of_vertices = 4 * 3;

	//int const starting_node = 0;

	//int graph[number_of_vertices][number_of_vertices] = {

	//	{ 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
	//	{ 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0},
	//	{ 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
	//	{ 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
	//	{ 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
	//	{ 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0},
	//	{ 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0},
	//	{ 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1},
	//	{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
	//	{ 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0},
	//	{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1},
	//	{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0}
	//};

	
	/*int const number_of_vertices = 4;
	int const starting_node = 0;


	int graph[number_of_vertices][number_of_vertices] = {
		{0, 1, 0, 0},
		{1, 0, 0, 1},
		{0, 0, 0, 0},
		{0, 1, 0, 0}												
	};*/

	

	//int maze[number_of_cols][number_of_rows] = { { 1, 1, 1},
	//											 { 1, 0, 1},
	//											 { 1, 0, 1} };				// DLA TAKIEGO INPUTU 

	//int const number_of_vertices_in_graph = number_of_cols * number_of_rows; // GRAPH 


	//int graph[number_of_vertices_in_graph][number_of_vertices_in_graph];

	//MazeToGraph(maze, number_of_vertices_in_graph);

	/*int const number_of_vertices = 9;

	int const starting_node = 0;


	int graph[number_of_vertices][number_of_vertices] = { { 0,    1,      0,      1,      0,      0,      0,      0,      0 }, 
														  { 1,    0,      1,      0,      0,      0,      0,      0,      0 },
														  { 0,    1,      0,      0,      0,      1,      0,      0,      0 },
														  { 1,    0,      0,      0,      0,      0,      1,      0,      0 },
														  { 0,    0,      0,      0,      0,      0,      0,      0,      0 },
														  { 0,    0,      1,      0,      0,      0,      0,      0,      1 },
														  { 0,    0,      0,      1,      0,      0,      0,      0,      0 },
														  { 0,    0,      0,      0,      0,      0,      0,      0,      0 },
														  { 0,    0,      0,      0,      0,      1,      0,      0,      0 }
	};






	int cost[number_of_vertices][number_of_vertices];

	int distance[number_of_vertices], predecessor[number_of_vertices] , visited_vertices[number_of_vertices];


	*/

	int const starting_node = 418;

	auto start = std::chrono::steady_clock::now();


	
	//dijkstra(&graph[0][0], number_of_vertices, starting_node, &cost[0][0], distance, predecessor, visited_vertices);


	//dijkstra_old(graph, number_of_vertices, starting_node);

	DijkstraASM(&graph[0][0], number_of_vertices, starting_node, &cost[0][0], distance, predecessor, visited_vertices);

	auto end = std::chrono::steady_clock::now();

	std::cout << "Elapsed time in nanoseconds : "
		<< std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count()
		<< " ns" << std::endl;



	/*printf(" cost: \n");

	for (int i = 0; i < number_of_vertices; i++)
	{
		for (int j = 0; j < number_of_vertices; j++) {

			printf("%5d\t", cost[i][j]);

		}

		printf(" \n");
	}
	*/
	printf(" \n visited_vertices: \n");

	for (int j = 0; j < number_of_vertices; j++) {

		printf("%5d\t", visited_vertices[j]);

	}


	printf(" \n predecessor: \n");

	for (int j = 0; j < number_of_vertices; j++) {

		printf("%5d\t", predecessor[j]);

	}


	printf(" \n distance: \n");

	for (int j = 0; j < number_of_vertices; j++) {

		printf("%5d\t", distance[j]);

	}


	printf(" \n result");

	int j = 0;

	//print the path and distance of each node
	//for (int i = 0; i < number_of_vertices; i++)
	//	if (i != starting_node)
	//	{
	//		printf("\nDistance of node%d=%d", i, distance[i]);
	//		printf("\nPath=%d", i);

	//		j = i;
	//		do
	//		{
	//			j = predecessor[j];
	//			printf("<-%d", j);
	//		} while (j != starting_node);
	//	}



	printf(" \n result");

	 j = 0;
	

	int target = 479;
		if (target != starting_node)
		{
			printf("\nDistance of node%d=%d", target, distance[target]);
			printf("\nPath=%d", target);

			printf("\n{");

			j = target;
			do
			{
				j = predecessor[j];
				printf("%d, ", j);
			} while (j != starting_node);

			printf("}");
		}






	//dijkstra(graph, number_of_vertices, 6);

	return 0;
}



