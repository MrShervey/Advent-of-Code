array = [[[89, 84, 88, 78, 70],"old * 5",7,6,7],[[76, 62, 61, 54, 69, 60, 85],"old + 1",17,0,6],[[83, 89, 53],"old + 8",11,5,3],[[95, 94, 85, 57],"old + 4",13,0,1],[[82,98],"old + 7",19,5,2],[[69],"old + 2",2,1,3],[[82, 70, 58, 87, 59, 99, 92, 65],"old * 11",5,7,4],[[91, 53, 96, 98, 68, 82],"old * old",3,4,2]]
count = [0,0,0,0,0,0,0,0]
for round in range(10000):
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
            #p1changedItem = changedItem //3
            changedItem = changedItem % 9699690
            if (changedItem % currentMonkey[2]) == 0:
                newMonkey = currentMonkey[3]
                array[newMonkey][0].append(changedItem)
                array[monkey][0].remove(currentItems[0])
            else:
                newMonkey = currentMonkey[4]
                array[newMonkey][0].append(changedItem)
                array[monkey][0].remove(currentItems[0])
            count[monkey] += 1

sortedCount = sorted(count, reverse=True)
monkeyBusiness = sortedCount[0] * sortedCount[1]
print(monkeyBusiness)