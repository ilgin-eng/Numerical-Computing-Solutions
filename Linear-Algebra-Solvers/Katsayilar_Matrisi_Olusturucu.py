def Katsayilarmatrisi(istenenmertebe,x,y):
    matris = [[0 for _ in range(istenenmertebe+2)] for _ in range(istenenmertebe+1)]
    for i in range(len(matris)):
        for j in range(len(matris[i])):
            for sayac in range(len(x)):
                if(j!=len(matris[i])-1):                            
                    matris[i][j]+=x[sayac]**(i+j)                   #matrisin sol tarafi
                else:                                               
                    matris[i][j]+=y[sayac]*x[sayac]**i              #matrisin sag tarafi
    return matris
def adondurucu(katsayilarmatrisi):
    a=[0 for _ in range(len(katsayilarmatrisi))]
    for cc in range(100):                                           #gauss yontemi
        for i in range(len(katsayilarmatrisi)):
            a[i]=katsayilarmatrisi[i][len(katsayilarmatrisi[i])-1]
            for j in range(len(katsayilarmatrisi[i])-1):
                if(i==j):
                    continue
                a[i]-=katsayilarmatrisi[i][j]*a[j]
            a[i]/=katsayilarmatrisi[i][i]
    return a
def E(a,x,y):                                                       #sigma[(y_ussu-y)^2]
    top=0
    for i in range(len(x)):
        yussu=0
        for j in range(len(a)):
            yussu+=a[j]*x[i]**j
        top+=(yussu-y[i])**2
    return top
def f(a,x):                                                         #yaklastirma ile buldugu fonksiyon
    sonuc=0
    for i in range(len(a)):
        sonuc+=a[i]*x**i
    return sonuc
x=[1,2,3,4,5]                                                   
y=[1,2,3,4,5]                                                       #degistirilebilir, burada y=x fonksiyonunu bulmali
eniyihata=11111
for i in range(1,6):                                                #1den 5 dahil en iyi mertebeyi seciyor
    istenenmertebe=i
    katsayilarmatrisi=Katsayilarmatrisi(istenenmertebe,x,y)
    a=adondurucu(katsayilarmatrisi)
    hata=E(a,x,y)
    if(hata<eniyihata):
        eniyihata=hata
        eniyia=a
n=2                                                                 #n = bolunen parca sayisi
hata2=5555
oran=0.001
while(hata2>oran):                                                  #altintegral ile ustintegral farkinin oranini 0.001 yapiyor
    altintegral,ustintegral=0,0                                     
    altsinir,ustsinir=1,6                                           #y=x fonksiyonunun 1-6 arasindaki integrali = 17.5(normalde)
    deltax = (ustsinir-altsinir)/n
    for i in range(n-1):
        altintegral += deltax*f(eniyia,altsinir)
        ustintegral+=deltax*f(eniyia,altsinir+deltax)
        altsinir += deltax
    n+=1
    hata2=(ustintegral-altintegral)/altintegral
    if(hata2<0):
        hata2*=-1
print(f"n={n}")
print(f"altintegral={altintegral}")
print(f"ustintegral={ustintegral}")