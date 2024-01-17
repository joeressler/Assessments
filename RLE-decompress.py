def compress(e):
    compressed = ""
    lastChar = ''
    count = 0

    for character in e[:-1]:
        if count == 0:
            count += 1
            lastChar = character
        else:
            if count < 9:
                if character == lastChar:
                    count += 1
                else:
                    compressed += (str(count) + lastChar)
                    lastChar = character
                    count = 1
            else:
                compressed += (str(count) + lastChar)
                count = 1
                lastChar = character

    else:
        if count < 9:
            if e[-1] == lastChar:
                count += 1
                compressed += (str(count) + lastChar)
            else:
                lastChar = e[-1]
                count = 1
                compressed += (str(count) + lastChar)
        else:
            compressed += (str(count) + lastChar)
            count = 1
            lastChar = e[-1]
            compressed += (str(count) + lastChar)

    return compressed


print(compress("ee0000000000OOOOppp000022uTwwqqozbkk33uoLLTTl666666666KQQQQQQQQEEA5xxxxxxxxxxxxxiiiiii"))




