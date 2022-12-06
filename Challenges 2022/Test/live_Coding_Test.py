# We want to create a program that:
# Takes three integers as inputs
# If the sum of the first and last numbers are greater than the second number then the second number is 
# subtracted from the third
# If not then then the sum of all three are calculated
# Return the result
# Multiply the result by the first number
# Print the value calculated

# Use three subroutines, and input validation

def getInput():
    valid = False
    number = input("Enter a number: ")
    while not valid:
        try:
            number = int(number)
            valid = True
        except ValueError:
            number = input("it needs to be a number")
    return number

def calculate(num1, num2, num3):
    if (num1 + num3) > num2:
        return num3-num2
    else:
        return num1+num2+num3

def final(first, result):
    print(result*first)

number1 = getInput()
final(number1,calculate(number1,getInput(),getInput()))