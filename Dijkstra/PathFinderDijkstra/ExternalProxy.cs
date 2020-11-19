using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace PathFinderDijkstra
{
    public unsafe class ExternalProxy
    {
        [DllImport("Asm.dll")]
        private static extern int computeDijkstra(int * graph, int number_of_vertices, int startnode, int* cost, int* distance, int* pred, int* visited);

		[DllImport("DLL_C.dll")]
		private static extern int computeDijkstraC(int* graph, int number_of_vertices, int startnode, int* cost, int* distance, int* pred, int* visited);

		public int executeDijkstraC(int[,] graph, int number_of_vertices, int start_node, int[,] cost, int[] distance, int[] predecessor, int[] visited_vertices)
		{
			unsafe
			{
				fixed (int* graphPtr = graph)
				{
					fixed (int* costPtr = cost)
					{
						fixed (int* distancePtr = distance)
						{

							fixed (int* predPtr = predecessor)
							{

								fixed (int* visitedPtr = visited_vertices)
								{

									return computeDijkstraC(graphPtr, number_of_vertices, start_node, costPtr, distancePtr, predPtr, visitedPtr);

								}
							}
						}
					}
				}
			}
		}


		public int executeDijkstraAsm(int[,] graph, int number_of_vertices, int start_node, int[,] cost, int[] distance, int[] predecessor, int[] visited_vertices)
        {
            unsafe
            {
                fixed (int* graphPtr = graph)
                {
                    fixed (int* costPtr = cost)
                    {
                        fixed (int* distancePtr = distance)
                        {

                            fixed (int* predPtr = predecessor)
                            {

                                fixed (int* visitedPtr = visited_vertices)
                                {

									return  computeDijkstra(graphPtr, number_of_vertices, start_node, costPtr, distancePtr, predPtr, visitedPtr);

								}
							}
                        }
                    }
                }
            }
        }
    }
}
