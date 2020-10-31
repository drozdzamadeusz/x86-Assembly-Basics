.model flat, c
.code

CountChar		proc

				push ebp
				mov ebp, esp
				push esi

				mov esi, [ebp + 8]			; esi = str
				mov cx, [ebp + 12]			; cx = char
				
				xor edx, edx				; ebx = 0 <- counter for char occurences

@@:

				lodsw						; Load word at address ESI into AX and then increment ESI by 2 bytes (16 bit) so it will point to next character
				or ax, ax					; test of end of the string 
				jz @F						; jump forward to next @@ label if end of the string found (IF AX == 0)
		
				cmp ax, cx					; compare current character with CX (character we looking for)
				jne @B						; jump backward to the next @@ label if no match

				inc edx						; increment match count
				jmp @B

@@:
				mov eax, edx				; set result

				pop esi
				pop ebp

				ret

CountChar		endp
end
