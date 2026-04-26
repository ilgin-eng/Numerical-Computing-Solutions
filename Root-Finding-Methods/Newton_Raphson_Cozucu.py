def f(x):
    return(x**5-7*x**4+18*x**3-22*x**2+13*x-3)

def fktryl(n):
    sonuc=1
    while(n!=0):
        sonuc*=n
        n-=1
    return sonuc

def kmbnsyn(n,k):
    pay=fktryl(n)
    payda=fktryl(k)*fktryl(n-k)
    return pay/payda

def turev(x,n):
    h=0.001
    sonuc=0
    for k in range(n+1):
        sonuc+=(-1)**(k+n)*kmbnsyn(n,k)*f(x+k*h)
    sonuc=1/h**n*sonuc
    return sonuc

x = float(input("baslangic tahmini girin: "))
hata=555
epsilon=0.0001
while(hata>epsilon):
    paydakontrol=turev(x,1)
    if(paydakontrol<0):
        paydakontrol*=-1
    if(paydakontrol<1e-10): #if(turev(x,1)==0):
        print("Bölme hatası")
        break
    xyeni = x - f(x)/turev(x,1)
    hata=xyeni-x
    if(hata<0):
        hata=-hata
    x=xyeni
else:
    print(x)
print(f"f(3)={f(3)}") #0 yazdırıyor, 3->gerçek kök
print(f"f(1)={f(1)}") #1->gerçek kök