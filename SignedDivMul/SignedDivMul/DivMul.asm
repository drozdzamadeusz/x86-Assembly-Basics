.386
.model flat,c

.code

; Return		: 0 Error (division by zero)
;				: 1 Success
;
; Computation	: *pord = a * b
;				: *quo = a / b
;				: *rem = a % b

IntegerDivMul	proc
				
				push ebp
				mov ebp,esp
				push ebx


				xor eax, eax			; will always set EAX to zero, its the same as mov eax, 0 but faster


				mov ecx, [ebp + 8]		; ecx = a
				mov edx, [ebp + 12]		; edx = b 

				or edx, edx				; executing OR will be set up flags, so we can chcek IF ZERO to avoid division by zero
				jz InvalidDivisor


				; MULTIPLICATION
				imul edx, ecx			; edx = edx * ecx

				mov ebx, [ebp + 16]		; ebx = prod
				mov [ebx], edx			; *ebx = edx, set value of ebx to edx
				;


				; DIVISION
				mov eax, ecx

				cdq							; Convert DWORD to QWORD, EAX contains result and EDX contains remainer

				idiv dword ptr[ebp + 12]	; EAX / A, signed divides eax by and saves result in EAX and remainer in EDX

				mov ebx, [ebp + 20]			; ebx = quo
				mov [ebx], eax				; *ebx = result
				
				mov ebx, [ebp + 24]			; ebx = rem
				mov [ebx], edx				; *ebx = remainer

				mov eax, 1					; if everything is ok return 1

InvalidDivisor:

				pop ebx
				pop ebp

				ret

IntegerDivMul	endp
				end