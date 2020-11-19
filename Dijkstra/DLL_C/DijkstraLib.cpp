#include "pch.h"

#define INFINITY 99999

extern "C"
{
	__declspec(dllexport)

	int __stdcall  computeDijkstraC(int* graph, int number_of_vertices, int startnode, int* cost, int* distance, int* pred, int* visited)
	{
		int count, mindistance, nextnode, i, j;

		//count gives the number of nodes seen so far
		//create the cost matrix
		for (i = 0; i < number_of_vertices; i++) {
			for (j = 0; j < number_of_vertices; j++) {

				int k = i * number_of_vertices + j;

				if (graph[k] == 0) {
					cost[k] = INFINITY;
				}
				else {
					cost[k] = graph[k];
				}
			}
		}

		//initialize previous[], distance[] and visited[]
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

		while (count < number_of_vertices)
		{
			mindistance = INFINITY;

			//nextnode gives the node at minimum distance
			for (i = 0; i < number_of_vertices; i++)
				if (distance[i] < mindistance && !visited[i])
				{
					mindistance = distance[i];
					nextnode = i;
				}

			//check if a better path exists through nextnod
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
		return 1;
	}

}