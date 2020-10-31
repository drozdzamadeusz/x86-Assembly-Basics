
.386
.model flat

.data
num1	dword	11111111h
num2	dword	10101010h
ans		dword	0 

.code
mian	PROC
		
		mov eax,num1
		add eax,num2

		mov ans,eax

		ret

mian	endp
end