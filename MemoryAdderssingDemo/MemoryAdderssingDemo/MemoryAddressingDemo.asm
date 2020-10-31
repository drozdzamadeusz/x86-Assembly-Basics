.386
.model flat,c

.const

;int FibVals[] = {0, 1, 1, 2, 3, 5, 8, 13,21, 34, 55, 89, 144, 233, 377, 610 };

FibVals		dword 0,1,1,2,3,5,8,13,21
			dword 34,55,89,144,233,377,610


; NumFibVals = sizeof(FibVals) / sizeof(int)

NumFibVals  dword($-FibVals)/sizeof dword

public	NumFibVals

.code

MemoryAddressing	proc
					
					push ebp
					mov ebp,esp
					push ebx
					push esi
					push edi

					xor eax, eax				; eax = 0
					mov ecx, [ebp + 8]			; ecx = i
					
					cmp ecx, 0
					jl InvalidIndex				; Jump If < than 0
					cmp ecx, [NumFibVals]
					jge InvalidIndex			; Jump If >= than number of items in array


					;Eg. 1 - Base Register

					mov ebx, offset FibVals		; ebx = FibVals

					mov esi, [ebp + 8]			; esi = i
					shl esi, 2					; esi = i * 4

					add ebx, esi				; ebx = FibVals + i * 4

					mov eax, [ebx]				; set result to eax

					mov edi, [ebp + 12]			; edi = v1
					mov [edi], eax				; v1 = eax
	

					; Eg. 2 - Base Register + Displacment

					mov esi, [ebp + 8]			; esi = i
					shl esi, 2					; esi = i * 4

					mov eax, [esi + FibVals]	; eax = i * 4 + FibVals

					mov edi, [ebp + 16]			; edi = v2
					mov [edi], eax				; v2 = eax


					; Eg. 3 - Base Register + Index Register

					mov ebx, offset FibVals

					mov esi, [ebp + 8]			; esi = i
					shl esi, 2					; esi = i * 4

					mov eax, [esi + ebx]		; eax = i * 4 + FibVals

					mov edi, [ebp + 20]
					mov [edi], eax

					
					; Eg. 4 - Base Register + Index Register * Scale Factor

					mov ebx, offset FibVals

					mov esi, [ebp + 8]

					mov eax, [esi * 4  +  ebx]

					mov edi, [ebp + 24]
					mov [edi], eax

					mov eax, 1

InvalidIndex:
					pop edi
					pop esi
					pop ebx
					pop ebp

					ret

MemoryAddressing	endp
					end