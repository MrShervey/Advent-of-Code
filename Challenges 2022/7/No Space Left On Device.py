def readFile():
    readData = []
    with open("Challenges 2022/7/input.txt") as f:
        for line in f:
            data  = line.strip()
            readData.append(data)
    return readData

instructions = readFile()
for x in range(len(instructions)):
    print(instructions[x])