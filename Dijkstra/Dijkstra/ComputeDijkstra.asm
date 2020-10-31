.model flat,c

.data

INFINITY dword 9999

mindistance dword ?
nextnode	dword ?

.code

DijkstraASM		proc

				push ebp
				mov ebp, esp
				push ebx
				push esi
				push edi

				xor eax, eax


				mov ecx, [ebp + 12]
				imul ecx, ecx

				mov edi, [ebp + 20]			; edi = cost matrix
				mov eax, [INFINITY]			; x  = 0
				rep stosd					; fill cost matrix with INFINITY
											;									STOSD (Store String)			-> Store EAX at address EDI,
											;									REP (Repeat String Instruction) -> Repeat operation the number of times in the ECX (by decrementing it)




				mov ebx, [ebp + 8]			; ebx = graph array
				xor esi, esi				; esi = i

;					Inner loop - Create Cost Matrix Inner Loop		i -> esi
					CostMatrixOuter:
					
					xor edi, edi			; j = 0
					mov edx, esi			; edx = esi

					imul edx, [ebp + 12]	; i * number_of_vertices


						CostMatrixInner:

						mov ecx, edx							; ecx = i * number_of_vertices
						add ecx, edi							; ecx = i * number_of_vertices + j
						mov eax, [ebx + ecx * 4]				; ecx = graph[i * number_of_vertices + j]		-> Each node in graph array


						cmp eax, 0								; Compare current vertex cost to 0
						je CostMatrixInnerEnd					; If current node is equal to 0 then omit further instructions

						mov ebx, [ebp + 20]						; Pointer to cost at corresponding location
						mov [ebx + ecx * 4], eax				; Set cost element vault to current vertex cost

						CostMatrixInnerEnd:

						mov ebx, [ebp + 8]						; Roll back ebx register to point to graph array					

						inc edi
						cmp edi, [ebp + 12]
						jl CostMatrixInner


					inc esi
					cmp esi, [ebp + 12]
					jl CostMatrixOuter




				xor esi, esi

				@@:

					mov ecx, [ebp + 12]				; number of vertices
					imul ecx, [ebp + 16]			; number of vertices * startnode
					add ecx, esi					; number of vertices * startnode + i

					mov ebx, [ebp + 20]				; pointer to cost array
					mov edx, [ebx + ecx * 4]		; edx =  cost field

					mov ebx, [ebp + 24]				; pointer to distance array
					mov [ebx + esi * 4] , edx

						

					inc esi
					cmp esi, [ebp + 12]
					jl @B




				mov ecx, [ebp + 12]

				mov edi, [ebp + 28]			; init pred with start_node
				mov eax, [ebp + 16]			; 
				rep stosd					; 

				mov ecx, [ebp + 12]

				mov edi, [ebp + 32]			; init visited with zeros 
				xor eax, eax				;
				rep stosd					; 




				mov ebx, [ebp + 16] ; start node
				xor esi, esi

				mov ecx, [ebp + 24]	; distance
				mov [ecx + ebx * 4], esi

				inc esi 

				mov ecx, [ebp + 32]	; visited
				mov [ecx + ebx * 4], esi



				mov esi, 2					; count
		
				OuterLoop: ;			i -> esi
				
				
					xor edi, edi			; j = 0


					mov edx, [INFINITY]
					mov mindistance, edx;; mindistance 

						InnerLoop:
						mov ecx, [ebp + 24]				; distance

						;mov edx, mindistance
						cmp edx, [ecx + edi * 4]
						jl InnerLoopEnd
						
						mov ecx, [ebp + 32]				; visited 
						mov ebx, [ecx + edi * 4]

						test ebx, ebx
						jnz InnerLoopEnd

						mov ecx, [ebp + 24]

						mov edx, [ecx + edi * 4]
						mov mindistance, edx

						mov eax, edi					;nextnode
						mov nextnode, eax

						InnerLoopEnd:
						inc edi
						cmp edi, [ebp + 12]
						jl InnerLoop



					mov ebx, 1

					mov ecx, [ebp + 32]	; visited

					mov eax, nextnode
					mov [ecx + eax * 4], ebx



						xor edi, edi

						InnerLoop1:									; EDX -> mindistance				 EAX -> nextnode

							
						mov ecx, [ebp + 32]							; pointer to visited array	
						mov ebx, [ecx + edi * 4]					; EBX = element in visited array

						test ebx, ebx								; test EBX
						jnz InnerLoop1End							; If current EBX is equal to 0 then omit further instructions

						;mov eax, nextnode							; Roll back pointer to nextnode variable
						mov ecx, eax								; ECX = nextnode

						imul ecx, [ebp + 12]						; ECX = nextnode * number_of_vertices
						add ecx, edi								; ECX = nextnode * number_of_vertices + i		(k)

						
						mov edx, [ebp + 20]							; Pointer to cost array
						mov ebx, [edx + ecx * 4]					; EBX = Element of corresponding element in cost array


						mov edx, mindistance						; Roll back pointer to nextnode variable
						add ebx, edx								; EBX = cost + mindistance
						

						mov edx, [ebp + 24]							; pointer to distance array
						mov ecx, [edx + edi * 4]					; single element in distance array
						cmp ecx, ebx								; mindistance + cost[k] < distance[i]							
						jl InnerLoop1End
						
						mov edx, [ebp + 24]							; Pointer to distance array
						mov [edx + edi * 4], ebx					; distance[i] = mindistance + cost[k];

						;mov eax, nextnode
						mov edx, [ebp + 28]							; Pointer to pred array
						mov [edx + edi * 4], eax					; pred[i] = nextnode;


						InnerLoop1End:
						inc edi
						cmp edi, [ebp + 12]
						jl InnerLoop1


					inc esi
					cmp esi, [ebp + 12]
					jl OuterLoop


				pop edi
				pop esi
				pop ebx
				pop ebp 

				ret

DijkstraASM		endp
end