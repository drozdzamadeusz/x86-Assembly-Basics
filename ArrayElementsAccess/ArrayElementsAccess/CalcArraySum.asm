.model flat, c
.code

CalcArraySumASM	proc


				push ebp
				mov ebp, esp


				mov edx, [ebp + 8]			; edx = x
				mov ecx, [ebp + 12]			; ecx = n

				xor eax, eax				; eax = 0

				cmp ecx, 0
				jle InvaildCount


@@:
				add eax, [edx]				; add edx to sum
				add edx, 4					; set pointer to next element

				dec ecx						; decrement counter 
				jnz @B						; Jump bakcward to nearest @@ if ecx is not equal to zero

				 
InvaildCount:

				pop ebp
				ret

				
CalcArraySumASM	endp
				end