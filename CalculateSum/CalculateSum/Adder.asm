.386
.model flat,c

.code

AdderASM proc

	push ebp				; prologe of the function
	mov ebp,esp				;

	mov eax, [ebp + 8]		; eax = a
	mov ecx, [ebp + 12]		; ecx = b
	mov edx, [ebp + 16]		; edx = c

	add eax, ecx			; a = a + b
	add eax, edx			; a = a + c
							; x86 uses register EAX to return value

	pop ebp					; poping EBP back - epilog fo the function

	ret


AdderASM endp
		 end