.model flat, stdcall

.data

INFINITY	dword 99999

mindistance dword ?
nextnode	dword ?

.code
;Cpp equiv:			       8					12					16				20				24			  28			32
computeDijkstra PROC	graph: Dword, number_of_vertices: Dword, startnode: Dword, cost: Dword, distance: Dword, pred: Dword, visited: Dword

				xor eax, eax													; Set value of eax to 0

				mov ecx, [number_of_vertices]									; ecx = number_of_vertices
				imul ecx, ecx													; ecx = ecx ^ 2

				mov edi, [cost]													; edi = cost matrix
				mov eax, [INFINITY]												; x  = Inf
				rep stosd														; init cost matrix with INFINITY

				mov esp, [graph]												; esp = graph array
				xor esi, esi													; esi = i


					;count gives the number of nodes seen so far
					;create the cost matrix
					CostMatrixOuter:											; Inner loop - Create Cost Matrix Inner Loop (esi -> i)
					
					xor edi, edi												; j = 0
					mov edx, esi												; edx = esi

					imul edx, [number_of_vertices]								; i * number_of_vertices

						CostMatrixInner:

						mov ecx, edx											; ecx = i * number_of_vertices
						add ecx, edi											; ecx = i * number_of_vertices + j
						mov eax, [esp + ecx * 4]								; ecx = graph[i * number_of_vertices + j]		-> Each node in graph array

						cmp eax, 0												; Compare current vertex cost to 0
						je CostMatrixInnerEnd									; If current node is equal to 0 then omit further instructions

						mov esp, [cost]											; Pointer to cost at corresponding location
						mov [esp + ecx * 4], eax								; Set cost element vault to current vertex cost

						CostMatrixInnerEnd:

						mov esp, [graph]										; Roll back esp register to point to graph array					

						inc edi													; Increment inner looop counter
						cmp edi, [number_of_vertices]							; Compare inner loop counter to number of vertices
						jl CostMatrixInner										; If loop conuter is still less than number of vertices then jump to begining of the loop


					inc esi														; Increment outer looop counter
					cmp esi, [number_of_vertices]								; Compare outer loop counter to number of vertices
					jl CostMatrixOuter											; If loop conuter is still less than number of vertices then jump to begining of the loop


				xor esi, esi													; Set value of eax to 0

				;initialize previous[], distance[] and visited[]
				@@:
					mov ecx, [number_of_vertices]								; number of vertices
					imul ecx, [startnode]										; number of vertices * startnode
					add ecx, esi												; number of vertices * startnode + i

					mov esp, [cost]												; pointer to cost array
					mov edx, [esp + ecx * 4]									; edx =  cost field

					mov esp, [distance]											; pointer to distance array
					mov [esp + esi * 4] , edx									; Set value of distance[number of vertices * startnode + i] to cost[number of vertices * startnode + i] 

						

				inc esi															; Increment looop counter								
				cmp esi, [number_of_vertices]									; Compare loop counter to number of vertices
				jl @B															; If loop conuter is still less than number of vertices then jump to begining of the loop



				mov ecx, [number_of_vertices]									; Set counter for rep

				mov edi, [pred]													; Init pred with start_node
				mov eax, [startnode]											; eax = startnode
				rep stosd														; Fill pred array with startnode


				mov ecx, [number_of_vertices]									; Set counter for rep

				mov edi, [visited]												; init visited with zeros 
				xor eax, eax													; eax = 0
				rep stosd														; fill visited array with zeros




				mov edi, [startnode]											; Pointer to start node
				xor esi, esi													; Set value of eax to 0

				mov ecx, [distance]												; Pointer to distance array
				mov [ecx + edi * 4], esi										; Set distance[startnode] to 0

				inc esi															; esi = 1

				mov ecx, [visited]												; Pointer to visited array
				mov [ecx + edi * 4], esi										; Set visited[startnode] to 1



				mov esi, 2														; Set outer loop conuter to 2 (esi -> i)
		
				OuterLoop:														; Outer Loop
					xor edi, edi												; Set inner loop counter to 0 (edi -> j)

					mov edx, [INFINITY]											; Set edx to INFINITY
					mov mindistance, edx										; Set mindistance to INFINITY

						; Nextnode gives the node at minimum distance 
						InnerLoop:
						mov ecx, [distance]										; Pointer to distance array

						cmp edx, [ecx + edi * 4]								; Compare INFINITY with current element of distance array
						jl InnerLoopEnd											; If eletemnt of distance array is not less than INFINITY then jump to epilogue of to loop
						
						mov ecx, [visited]										; Pointer to visited array
						mov esp, [ecx + edi * 4]								; Set esp to visited[i]

						test esp, esp											; Test if visited[i]
						jnz InnerLoopEnd										; If visited[i] if not equal 0 then jump to end of the function

						mov ecx, [distance]										; Pointer to distance array

						mov edx, [ecx + edi * 4]								; Move current element of distance array to edx register
						mov mindistance, edx									; Set value of  mindistance to current element of distance array

						mov eax, edi											; Set eax to inner loop counter
						mov nextnode, eax										; Set value of nextnode to inner loop counter value

						InnerLoopEnd:
						inc edi													; Increment inner looop counter
						cmp edi, [number_of_vertices]							; Compare inner loop counter to number of vertices
						jl InnerLoop											; If loop conuter is still less than number of vertices then jump to begining of the loop



					mov esp, 1													; esp = 1
					mov ecx, [visited]											; Pointer to visited array
					mov [ecx + eax * 4], esp									; visited[nextnode] = 1;	

					mov eax, nextnode											; EAX -> nextnode

					xor edi, edi												; edi = index

						; Check if a better path exists through nextnode
						InnerLoop1:

						mov ecx, [visited]										; Pointer to visited array	
						mov esp, [ecx + edi * 4]								; esp = element in visited array

						test esp, esp											; test esp
						jnz InnerLoop1End										; If current esp is equal to 0 then omit further instructions

						mov ecx, eax											; ECX = nextnode

						imul ecx, [number_of_vertices]							; ECX = nextnode * number_of_vertices
						add ecx, edi											; ECX = nextnode * number_of_vertices + i (k)

						
						mov edx, [cost]											; Pointer to cost array
						mov esp, [edx + ecx * 4]								; esp = Element of corresponding element in cost array


						add esp, mindistance									; esp = cost + mindistance
						

						mov edx, [distance]										; Pointer to distance array
						mov ecx, [edx + edi * 4]								; single element in distance array
						cmp ecx, esp											; mindistance + cost[k] < distance[i]							
						jl InnerLoop1End
						

						mov [edx + edi * 4], esp								; distance[i] = mindistance + cost[k];

						mov edx, [pred]											; Pointer to pred array
						mov [edx + edi * 4], eax								; pred[i] = nextnode;


						InnerLoop1End:
						inc edi													; Increment inner looop counter
						cmp edi, [number_of_vertices]							; Compare inner loop counter to number of vertices
						jl InnerLoop1											; If loop conuter is still less than number of vertices then jump to begining of the loop


					inc esi														; Increment outer looop counter
					cmp esi, [number_of_vertices]								; Compare outer loop counter to number of vertices
					jl OuterLoop												; If loop conuter is still less than number of vertices then jump to begining of the loop


				mov eax, 1														; Set proc output to 1 -> executed successfully
				ret																; so we can return it from the procedure
computeDijkstra ENDP

end

