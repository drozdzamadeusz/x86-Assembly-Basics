.386
.model flat

PBYTE TYPEDEF	PTR BYTE
PWORD TYPEDEF	PTR WORD
PDWORD TYPEDEF	PTR DWORD

.data

arrayB BYTE 10h, 20h, 30h
arrayW WORD 1, 2, 3
arrayD DWORD 4, 5, 6

pt_1 PBYTE arrayB
pt_2 PWORD arrayW
pt_3 PDWORD arrayD

.code

start	PROC

	mov esi, pt_1
	mov al, [esi]

	mov esi, pt_2
	mov ax, [esi]

	mov esi, pt_3
	mov eax, [esi]

	ret

start	endp
end start


