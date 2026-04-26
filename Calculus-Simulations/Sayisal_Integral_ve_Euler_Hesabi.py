def f(x):
    return 1/x

delta = 0.01
for i in range(5):
    integral,a=0,1
    while(integral<1):
        integral += delta*(f(a)+f(a+delta))/2
        a += delta
    #print(f"delta={delta}\t euler={a}")
    delta/=10
print(f"euler={a}")