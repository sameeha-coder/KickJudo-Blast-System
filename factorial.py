# Factorial Program
n = 6
factorial = 1

print("\nFactorial Calculation for n =", n)

for i in range(1, n + 1):
    factorial = factorial * i
    print(f"After multiplying by {i}: factorial = {factorial}")

print("Final Factorial:", factorial)

