def readfile():
    stack1 = [[],[],[],[],[],[],[],[],[]]
    f = open("Challenges 2022/5/input.txt", "r")
    for x in range(8):
        data = f.readline()
        items = data.split(" ")
        for y in range(9):
            if items[y][0:3] != "---":
                stack1[y].append(items[y][0:3])
    f.close()
    for z in range(9):
        stack1[z].reverse()
    return(stack1)

def readInstructions(stack):
    f = open("Challenges 2022/5/input.txt", "r")
    for x in range(10):
        f.readline()
    for line in f:
        instructions = []
        data = line.split(" ")
        inthree = data[5].split("\n")
        instructions.append(int(data[1]))
        instructions.append(int(data[3]))
        instructions.append(int(inthree[0]))
        stack = moveItems(instructions, stack)
    f.close()
    return stack

def moveItems(instructions, stack):
    for x in range(instructions[0]):
        startStack = instructions[1]-1
        endStack = instructions[2]-1
        if len(stack[startStack]) != 0:
            temp = stack[startStack].pop()
            stack[endStack].append(temp)
    return stack

def moveItemsp2(instructions, stack):
    temparray = []
    for x in range(instructions[0]):
        startStack = instructions[1]-1
        endStack = instructions[2]-1
        if len(stack[startStack]) != 0:
            temp = stack[startStack].pop()
            temparray.append(temp)
    for x in range(len(temparray)-1,-1,-1):
        stack[endStack].append(temparray[x])
    return stack

def getTopValues(stacks):
    topValues = []
    for x in range(9):
        topValues.append(stacks[x].pop())
    return topValues

stack = readfile()
finalStacks = readInstructions(stack)
print(getTopValues(finalStacks))