def compareP1(array1, array2):
    if array1[0] >= array2[0] and array1[1] <= array2[1]:
        return True
    elif array2[0] >= array1[0] and array2[1] <= array1[1]:
        return True
    else:
        return False

def compareP2(array1, array2):
    if array1[0] >= array2[0] and array1[0] <= array2[1]:
        return True
    elif array1[1] >= array2[0] and array1[1] <= array2[1]:
        return True
    elif array2[0] >= array1[0] and array2[1] <= array1[1]:
        return True
    elif array2[1] >= array1[0] and array2[1] <= array1[1]:
        return True
    else:
        return False

def readFile():
    totalP1 = 0
    totalP2 = 0
    f = open("Challenges 2022/4/input.txt", "r")
    for line in f:
        data = line.split(",")
        array1 = data[0].split("-")
        array1[0] = int(array1[0])
        array1[1] = int(array1[1])
        temp1 = data[1].split("-")
        temp2 = temp1[1].split("\n")
        array2 =[]
        array2.append(int(temp1[0]))
        array2.append(int(temp2[0]))
        if compareP1(array1,array2):
            totalP1 += 1
        if compareP2(array1,array2):
            totalP2 += 1
    f.close()
    print("Part 1: ", totalP1)
    print("Part2: ", totalP2)

readFile()    