import random
import operator

def PrintPilesWithSymbols(symbols_for_stones):
    nums = 3
    spacer = 7
    for item in range(nums):
        top_bottom_side = ''
        middle_side = ''
        space_between = " " * spacer
        row_num = item % nums
        for index in symbols_for_stones:
            current_symbol = index
            top_bottom_side += f" {current_symbol * (nums+2)} "
            top_bottom_side += space_between
            middle_side += (f"{current_symbol}{' ' * (nums+2)}{current_symbol}")
            middle_side += space_between
        if row_num in (0, nums-1):
            print(top_bottom_side)
        else:
            print(middle_side)

def PrintPiles():
    temp_piles = piles.copy()
    print(temp_piles)
    pile_height_max = max(temp_piles)
    for pile in range(pile_height_max):
        symbols_for_stones = [' ' for i in temp_piles]
        x = temp_piles
        pile_height = max(temp_piles)
        get_max_piles_indexes = lambda x, xs: [i for (y, i) in zip(xs, range(len(xs))) if x == y]
        for i in get_max_piles_indexes(pile_height,x):
            symbols_for_stones[i] = '*'
            temp_piles[i] -= 1
        PrintPilesWithSymbols(symbols_for_stones)

# def BotTurn(total_amount_of_stones):
#     chosen_pile = random.randint(1, len(piles))
#     chosen_number_of_stones = random.randint(1, piles[chosen_pile - 1])
#     piles[chosen_pile - 1] -= chosen_number_of_stones
#     total_amount_of_stones -= chosen_number_of_stones
#     if 0 in piles:
#         piles.remove(0)
#     print(f"Обрана купа: {chosen_pile}\nКількість камінців: {chosen_number_of_stones}")
#     return total_amount_of_stones

def Separator():
    custom_console_width = 80
    for i in range(custom_console_width):
        print("=",end='')
    print()

def InitiatePiles():
    max_pile_number = 6
    min_pile_number = 1
    max_stone_number = 6
    min_stone_number = 1
    _exit_ = False
    while not(_exit_):
        _choose_ = int(0)
        while _choose_ != 1 and _choose_ != 2:
            try:
                _choose_ = int(input("Оберіть спосіб створення умов гри:\n1 - Вручну\n2 - Автоматично\n"))
            except:
                print("Такого способу немає. Спробуйте ще...")
        if _choose_ == 1:
            _piles_str = input("Введіть кількість камінців у кожній купі (Наприклад: 1, 3, 5, 6, ...): ")
            _piles_int = [int(i) for i in _piles_str.split() if i.isdigit() and i != 0]
            print(f"Кількість куп з камінням: {len(_piles_int)}")
            for i in range(len(_piles_int)):
                print(f"Кількість камінців у {i + 1} купі: {_piles_int[i]}")
        elif _choose_ == 2:
            num_of_piles = random.randint(min_pile_number, max_pile_number)
            print(f"Кількість куп з камінням: {num_of_piles}")
            _piles_int = [0] * num_of_piles
            for i in range(num_of_piles):
                _piles_int[i] = random.randint(min_stone_number, max_stone_number)
                print(f"Кількість камінців у {i + 1} купі: {_piles_int[i]}")
        Separator()
        _choose_ = 0
        while _choose_ != 1 and _choose_ != 2:
            try:
                _choose_ = int(input("Такі умови гри вас влаштовують? 1 - Так, 2 - Ні "))
            except:
                print("Спробуйте ще...")
        if _choose_ == 1:
            _exit_ = True
        else:
            Separator()
    return _piles_int

def NextPlayer(current_player):
    if current_player == players[0]:
        current_player = players[1]
    else:
        current_player = players[0]
    return current_player

def NimSum():
    nim = 0
    for i in range(len(piles)):
        nim = operator.xor(nim, piles[i])
    return nim

def AiMove():
    print("Хід бота")
    Separator()
    nim = int(NimSum())
    print(nim)
    index = 0
    if(nim == 0):
        print(f"Обрана купа: {index+1}\nКількість камінців: {1}")
        piles[index] -= 1
    else:
        while(operator.xor(piles[index], nim) >= piles[index]) and (index < len(piles)):
            index += 1
        print(f"Обрана купа: {index + 1}\nКількість камінців: {piles[index] - operator.xor(piles[index], nim)}")
        piles[index] = operator.xor(piles[index], nim)
    if 0 in piles:
        piles.remove(0)

def PlayerMove():
    pile_number= 999999
    count_of_stones = 999999
    while (pile_number - 1 >= len(piles)) or (pile_number <= 0):
        try:
            pile_number = int(input('З якої стопки хочете взяти камінці? '))
        except:
            print("Такої стопки немає. Спробуйте ще...")
    while (count_of_stones > piles[pile_number - 1]) or (count_of_stones <= 0):
        try:
            count_of_stones = int(input('Скільки камінчиків хочете взяти? '))
        except:
            print("Такої кількості камінчиків немає. Спробуйте ще...")
    piles[pile_number - 1] -= count_of_stones
    if 0 in piles:
        piles.remove(0)

def NewMoveWithAi(current_move : int):
    Separator()
    PrintPiles()
    Separator()
    if current_move == 1:
        PlayerMove()
    else:
        AiMove()
    current_move = (current_move + 1) % 2
    return current_move

def NewMoveWithPlayer(current_move : int):
    Separator()
    PrintPiles()
    Separator()
    print(f"Хід користувача {players[current_move]}")
    Separator()
    PlayerMove()
    current_move = (current_move + 1) % 2
    return current_move

if __name__ == '__main__':
    players = dict()
    Separator()
    print("Привіт) Це гра Нім(Nim)! Мене створив Литвинчук Владислав з ІПЗ-11")
    Separator()
    piles = InitiatePiles()
    Separator()
    _choose_ = int(0)
    while _choose_ != 1 and _choose_ != 2:
        try:
            _choose_ = int(input("Оберіть:\n1 - Гра з людиной\n2 - Гра з ботом\n"))
        except:
            print("Такого способу немає. Спробуйте ще...")
    if _choose_ == 1:
        players[0] = input("Введіть ім'я першого гравця: ")
        Separator()
        players[1] = input("Введіть ім'я другого гравця: ")
        current_move = random.randint(0,1)
        while len(piles) != 0:
            current_move = NewMoveWithPlayer(current_move)
            if len(piles) == 0:
                print(f"Гравець {players[(current_move + 1) % 2]} переміг!")
                Separator()
    else:
        current_move = random.randint(0, 1)
        while len(piles) != 0:
            current_move = NewMoveWithAi(current_move)
            if len(piles) == 0:
                if current_move == 0:
                    print("Мої вітання, ви перемогли")
                else:
                    print("Ви програли боту :(")
                Separator()
