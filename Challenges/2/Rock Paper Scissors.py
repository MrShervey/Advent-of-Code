def getCards(play):
    oppo = 0
    player = 0
    result = ""
    if play[0] == "A":
        oppo = 1
    elif play[0] == "B":
        oppo = 2
    else:
        oppo = 3
    if play[1] == "X":
        player = 1
    elif play[1] == "Y":
        player = 2
    else:
        player = 3
    #Part 1
    #return calculateWinner(oppo, player)
    #Part 2
    return partTwo(oppo, play[1])


def calculateWinner(oppo,player):   
    if (oppo == 2 and player == 1) or (oppo == 3 and player == 2) or (oppo == 1 and player == 3):
        result = "Lose"
    elif (player == 2 and oppo == 1) or (player == 3 and oppo == 2) or (player == 1 and oppo ==3):
        result = "Win"
    else:
        result = "Draw"
    return result

def partTwo(oppo, player):
    score = 0
    if player == "Y":
        score = oppo + 3
    elif player == "Z":
        score = 6
        if oppo == 1:
            score += 2
        elif oppo == 2:
            score += 3
        else:
            score += 1
    elif player == "X":
        if oppo == 1:
            score = 3
        elif oppo == 2:
            score = 1
        else:
            score = 2
    return score

def calculateScore(result, playerChoice):
    score = 0
    if result == "Win":
        score += 6
    elif result == "Draw":
        score += 3
    if playerChoice == "X":
        score += 1
    elif playerChoice == "Y":
        score += 2
    else:
        score += 3
    return score

def readFile():
    total = 0    
    f = open("Challenges/2/input.txt","r")
    for line in f:
        finalData = []
        data = line.split(" ")
        p = data[1].split("\n")
        finalData.append(data[0])
        finalData.append(p[0])
        #part 1
        #total += calculateScore(getCards(finalData),finalData[1])
        #part 2
        total += getCards(finalData)

    f.close()
    return total

print(readFile())

