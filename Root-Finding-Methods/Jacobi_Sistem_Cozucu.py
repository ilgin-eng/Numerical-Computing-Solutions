def enbuyuk(a,b,c):
    if(a>=b and a>=c):
        return a
    if(b>=a and b>=c):
        return b
    if(c>=a and c>=b):
        return c
xeski,yeski,zeski = 4,7,5 #0 verilirse bölme hatası oluyor
oran=float(input())
hata=100
while(hata>oran):
    xyeni,yyeni,zyeni = (13-3*yeski-zeski)/9, (6+zeski-2*xeski)/5, (2+6*xeski)/8
    if(xyeni==0 or yyeni==0 or zyeni==0):
        break
    xhata,yhata,zhata=(xyeni-xeski)/xeski,(yyeni-yeski)/yeski,(zyeni-zeski)/zeski
    hata=enbuyuk(xhata,yhata,zhata)
    if(hata<0):
        hata*=-1
    xeski,yeski,zeski=xyeni,yyeni,zyeni
print((xeski, yeski, zeski))