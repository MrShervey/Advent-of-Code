def readfile():
    values = []
    f = open("Challenges 2021/2/input.txt", "r")
    for line in f:
        contents = []
        data = line.split(" ")
        temp = data[1].split("\n")
        contents.append(data[0])
        contents.append(int(temp[0]))
        values.append(contents)
    f.close()
    return values

def moveSubp1():
    instructions = readfile()
    x = 0
    y = 0
    for b in range(len(instructions)):
        if instructions[b][0] == "forward":
            x += instructions[b][1]
        elif instructions[b][0] == "down":
            y += instructions[b][1]
        elif instructions[b][0] == "up":
            y -= instructions[b][1]
    print("Part 1: ", x*y)

def moveSubp2():
    instructions = readfile()
    horizontal = 0
    depth = 0
    aim = 0
    for b in range(len(instructions)):
        if instructions[b][0] == "forward":
            horizontal += instructions[b][1]
            depth += (instructions[b][1] * aim)
        elif instructions[b][0] == "down":
            aim += instructions[b][1]
        elif instructions[b][0] == "up":
            aim -= instructions[b][1]
    print("Part 2: ", horizontal * depth)

moveSubp1()
moveSubp2()