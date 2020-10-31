; FINDING NON-ZERO NUMBER
.386
.model flat

.data

intArray SWORD 0, 0, 0;, 5, 3, 0, -34, -56, 7, 8

.code

start	PROC
	
		mov ebx, OFFSET intArray	; Set Base Pointer to the the array
		mov ecx, LENGTHOF intArray	; Set loop counter for loop operations
LP:		
		cmp WORD PTR[ebx],0			; Compare Base Register with 0

		jne found					; If not equal then go to found, non-zero number found

		add ebx, TYPE intArray		; Add size of one item in array, point to next item

		loop LP						; Loop

		jmp notFound

found:
		movsx eax, WORD PTR[ebx]	; Move result Base Register to Accumulator

		jmp quit

notFound:
		
		mov eax, 999999

quit:
		ret

start	endp
end		start