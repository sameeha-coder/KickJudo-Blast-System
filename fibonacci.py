# Fibonacci Series Program
n = 6
first = 0
second = 1

print("Fibonacci Series for n =", n)
print(first, second, end=" ")

for i in range(3, n + 1):
    next_num = first + second
    print(next_num, end=" ")
    first = second
    second = next_num


