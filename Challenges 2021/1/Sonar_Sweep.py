def readfile():
    values = []
    f = open("Challenges 2021/1/input.txt", "r")
    for line in f:
        data = line.split("\n")
        values.append(int(data[0]))
    f.close()
    return values

def countIncreasesP1(valueSet):
    count = 0
    for x in range(len(valueSet)-1):
        if valueSet[x+1] > valueSet[x]:
            count += 1
    return count

def countIncreasesP2(valueSet):
    count = 0
    swap = True
    rangeA = valueSet[0]+valueSet[1]+valueSet[2]
    rangeB = valueSet[1]+valueSet[2]+valueSet[3]
    if rangeB > rangeA:
        count += 1
    for x in range(2,len(valueSet)-2):
        if swap:
            rangeA = valueSet[x]+valueSet[x+1]+valueSet[x+2]
            if rangeA > rangeB:
                count += 1
            swap = False
        else:
            rangeB = valueSet[x]+valueSet[x+1]+valueSet[x+2]
            if rangeB > rangeA:
                count += 1
            swap = True
    return count

print("Part 1: ", countIncreasesP1(readfile()))
print("Part 2: ", countIncreasesP2(readfile()))