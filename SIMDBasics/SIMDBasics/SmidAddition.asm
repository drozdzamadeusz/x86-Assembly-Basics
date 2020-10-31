.model flat, c
.data

my_ints1 DWORD 1, 2, 3, 4
my_ints2 DWORD 5, 5, 5, 5

.code
SMIDTest	proc

			movdqu xmm0, xmmword ptr[my_ints1]
			movdqu xmm1, xmmword ptr[my_ints2]

			psubd	xmm0, xmm1

SMIDTest	endp
end
