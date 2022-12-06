def readfile():
    dataInput = []
    f = open("Challenges 2021/3/input.txt", "r")
    for line in f:
        data = line.split("\n")
        dataInput.append(data[0])
    f.close()
    return dataInput

def parseData(dataset):
    gamma = ""
    epsilon = ""
    for y in range(len(dataset[0])):
        one = 0
        zero = 0
        for x in range(len(dataset)):
            if dataset[x][y] == "1":
                one += 1
            else:
                zero += 1
        if one > zero: 
            gamma += "1"
            epsilon += "0"
        else:
            epsilon += "1"
            gamma += "0"
    return int(gamma,2) * int(epsilon,2)

def partTwo(dataset,rating):
    length  = len(dataset)
    stop = False
    count = 0
    while count < length and len(dataset) > 1:
        dataset = checkDigits(dataset,count,rating)
        count += 1
    return dataset

def checkDigits(data,index,rating):
    one = 0
    zero = 0
    for x in range(len(data)):
        if data[x][index] == "1":
            one += 1
        else:
            zero += 1
    if rating == "oxy":
        if one >= zero:
            value = "1"
        else:
            value = "0"
    else:
        if one < zero:
            value = "1"
        else:
            value = "0"
    data = getDigits(data, value, index)
    return data

def getDigits(data, value, index):
    found = []
    for x in range(len(data)):
        if data[x][index] == value:
            found.append(data[x])
    return found

print("Part 1: ", parseData(readfile()))
oxygen = partTwo(readfile(),"oxy")
carbon = partTwo(readfile(),"carb")
print("Part 2: ",int(oxygen[0],2) * int(carbon[0],2))


