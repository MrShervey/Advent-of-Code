array = [[[79, 98],"old * 19",23,2,3],[[54, 65, 75, 74],"old + 6",19,2,0],[[79, 60, 97],"old * old",13,1,3],[[74],"old + 3",17,0,1]]
count = [0,0,0,0,0,0,0,0]
for round in range(20):
    for monkey in range(len(array)):
        currentMonkey = array[monkey]
        currentItems = currentMonkey[0]
        while len(currentItems) > 0:
            calcInstr = currentMonkey[1].split(" ")
            if calcInstr[2] == "old":
                worryCalc = currentItems[0]
            else:
                worryCalc = int(calcInstr[2])
            if calcInstr[1] == "*":
                changedItem = currentItems[0] * worryCalc
            elif calcInstr[1] == "+":
                changedItem = currentItems[0] + worryCalc
            changedItem = changedItem // 3
            if (changedItem % currentMonkey[2]) == 0:
                newMonkey = currentMonkey[3]
                array[newMonkey][0].append(changedItem)
                array[monkey][0].remove(currentItems[0])
            else:
                newMonkey = currentMonkey[4]
                array[newMonkey][0].append(changedItem)
                array[monkey][0].remove(currentItems[0])
            count[monkey] += 1


#print(count)
sortedCount = sorted(count, reverse=True)
# print(sortedCount)
monkeyBusiness = sortedCount[0] * sortedCount[1]
print(monkeyBusiness)
# for x in range(len(array)):
#     print(array[x][0])