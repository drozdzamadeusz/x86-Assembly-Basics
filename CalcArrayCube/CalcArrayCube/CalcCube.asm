.model flat, c

.code
CalcArrayRowColSumASM	proc

						push ebp
						mov ebp, esp
						push ebx
						push esi
						push edi

						xor eax, eax
						cmp dword ptr[ebp + 12], 0			; Check if nrows is not less than 0
						jle	InvaildArg

						mov ecx, [ebp + 16]
						cmp ecx, 0							; Check if ncols is not less than 0
						jle InvaildArg


						mov edi, [ebp + 24]					; edi = col_sums
						xor eax, eax
						rep stosd							; Fill col_sums array with zeros,	STOSD (Store String)			-> Store EAX at address EDI,
															;									REP (Repeat String Instruction) -> Repeat operation the number of times in the ECX (by decrementing it)

						mov ebx, [ebp + 8]					; ebp = x (source array)
						xor esi, esi						; i = 0

Lp1:
						; Outer loop	i -> esi
						mov edi, [ebp + 20]					; edi = row_sums
						mov dword ptr [edi + esi * 4], 0	; rows_sums[i] = 0

						xor edi, edi						; j = 0
						mov edx, esi						; edx = i						

						imul edx, [ebp + 16]				; edx = i * ncols				calculate new row location
															;								edx is used to store current row location (i * ncols), esi is index


Lp2:
						; Inner loop	j -> edi

						mov ecx, edx						; ecx = i * ncols
						add ecx, edi						; ecx = i * ncols + j
						mov eax, [ebx + ecx * 4]			; ecx = x[i * ncols + j]		current item

						mov ecx, [ebp + 20]					; ecx = row_sums
						add [ecx + esi * 4], eax			; row_sums[i] += eax

						mov ecx, [ebp + 24]					; ecx = col_sums
						add [ecx + edi * 4], eax			; col_sums[j] += eax


						inc edi								; j++
						cmp edi, [ebp + 16]					; compare j and ncols
						jl Lp2								; jump if j < ncols

						inc esi								; i++
						cmp esi, [ebp + 12] 				; jump if i < nrow
						jl Lp1

						mov eax, 1

InvaildArg:
						pop edi
						pop esi
						pop ebx
						pop ebp 

						ret

CalcArrayRowColSumASM	endp
end
