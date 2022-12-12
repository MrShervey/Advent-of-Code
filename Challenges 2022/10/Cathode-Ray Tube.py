global totalSignalStrength
totalSignalStrength = 0

def readFile():
    instructions = []
    with open("Challenges 2022/10/input.txt") as f:
        for line in f:
            data = line.strip()
            lineInstructions = data.split(" ")
            instructions.append(lineInstructions)
    return instructions

def checkCycle(cycle,x,data,lines):
    global totalSignalStrength
    if cycle == 20 or cycle == 60 or cycle == 100 or cycle == 140 or cycle == 180 or cycle == 220:
        signalStrength = cycle * x
        totalSignalStrength += signalStrength

data = readFile()
cycle = 0
x = 1
for lines in range(len(data)):
    if data[lines][0] == "noop":
        cycle += 1
        checkCycle(cycle,x,data[lines],lines)
    elif data[lines][0] == "addx":
        cycle +=1
        checkCycle(cycle,x,data[lines],lines)
        cycle +=1
        checkCycle(cycle,x,data[lines],lines)
        x += int(data[lines][1])

print(totalSignalStrength)