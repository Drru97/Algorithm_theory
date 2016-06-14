from math import sqrt


class Item:
    def __init__(self, data):
        self.data = data
        self.next = None
        self.previous = None


class List:
    def __init__(self):
        self.first = None
        self.last = None

    def add_begin(self, data):
        temp = Item(data)
        temp.next = self.first
        temp.previous = None
        if self.first is not None:
            self.first.previous = temp
        else:
            self.last = temp
        self.first = temp

    def del_begin(self):
        if self.first is None:
            return
        temp = self.first
        self.first = temp.next
        if self.first is not None:
            self.first.previous = None
        else:
            self.last = None

    def del_end(self):
        if self.first is None:
            return
        temp = self.last
        self.last = temp.previous
        if self.first is not None:
            self.last.next = None
        else:
            self.first = None

    def search(self, data):
        temp = self.first
        while temp is not None:
            if temp.data == data:
                return temp
            else:
                temp = temp.next
        return None

    def del_mid(self, data):
        temp = self.search(data)
        if temp is None:
            return
        if self.first == temp:
            self.del_begin()
            return
        if self.last == temp:
            self.del_end()
            return
        temp.previous.next = temp.next
        temp.next.previous = temp.previous

    def show(self):
        temp = self.first
        show_string = ""
        while temp != None:
            show_string += str(temp.data) + " "
            temp = temp.next
        return show_string


class OpenHashTable:
    def __init__(self, m):
        self.m = m
        self.T = [List() for i in range(0, m)]
        self.function = "division"
        self.A = (sqrt(5) - 1) / 2

    # метод ділення
    def h(self, k):
        if self.function == "division":
            return k % self.m
        else:
            return int(str(m * ((k * self.A) % 1)).split(".")[0])

    def Chained_Hash_Insert(self, x):
        self.T[self.h(x)].add_begin(x)

    def Chained_Hash_Search(self, k):
        temp = self.T[self.h(k)].search(k)
        return temp

    def Chained_Hash_Delete(self, x):
        self.T[self.h(x)].del_mid(x)

    def ShowHashTable(self):
        for i in range(0, len(self.T)):
            print(i, self.T[i].show())


class ClosedHashTable:
    def __init__(self, m):
        self.m = m
        self.T = [-998 for i in range(0, m)]
        self.function = "quadratic"

    def h(self, k, i):
        c1 = 1
        c2 = 3
        if self.function == "linear":
            return (self.h1(k)+i) % self.m
        if self.function == "quadratic":
            return (self.h1(k) + c1*i + c2*(i**2)) % self.m
        if self.function == "double":
            return (self.h1(k) + i*self.h2(k)) % self.m

    def h1(self, k):
        return k % self.m

    def h2(self, k):
        return 1 + (k % (self.m - 1))


    def HashInsert(self, k):
        i = 0
        while True:
            j = self.h(k, i)
            if self.T[j] == -998 or self.T[j] == -999:
                self.T[j] = k
                return j
            else:
                i += 1
            if i == m:
                break
        print("Хеш-таблиця переповнена")


    def HashSearch(self, k):
        i = 0
        while True:
            j = self.h(k, i)
            if self.T[j] == k:
                print("Це елемент під номером {}".format(j))
                return j
            i += 1
            if self.T[j] == 0 or i == m:
                break
        print("Елемент не знайдено")

    def HashDelete(self, k):
        i = 0
        while True:
            j = self.h(k, i)
            if self.T[j] == k:
                self.T[j] = -999
                return
            i += 1
            if self.T[j] == -998 or i == m:
                break
        print("Елемент не знайдено")


    def ShowHashTable(self):
        for i in range(0, len(self.T)):
            print(i, self.T[i])

m = 11
keys = [10, 22, 31, 4, 15, 28, 17, 88, 59]


while True:
    choice = input("1 - Відкрите хешування, 2 - Закрите хешування, 3 - вихід")
    if choice == "1":
        Hash = OpenHashTable(m)
        choice = input("Вставка таблиці методом 1 - ділення, 2 - множення")
        if choice == "1":
            Hash.function = "division"
        if choice == "2":
            Hash.function = "multiplication"

        while True:
            choice = input("1 - Вставка, 2 - Пошук, 3 - Видалення, 4 - змінити метод, 5 - показати, 6 - вихід\n")
            if choice == "1":
                x = int(input("Введіть елемент, який хочете вставити: "))
                print(Hash.Chained_Hash_Insert(x))
                Hash.ShowHashTable()
            if choice == "2":
                x = int(input("Введіть елемент, який хочете знайти: "))
                print(Hash.Chained_Hash_Search(x))
                Hash.ShowHashTable()
            if choice == "3":
                x = int(input("Введіть елемент, який хочете видалити: "))
                Hash.Chained_Hash_Delete(x)
                Hash.ShowHashTable()
            if choice == "4":
                choice = input("1 - метод ділення, 2 - метод множення")
                if choice == "1":
                    Hash.function = "division"
                    print("Метод змінено на ділення")
                if choice == "multiplication":
                    Hash.function = "multiplication"
                    print("Метод змінено на множення")
            if choice == "5":
                Hash.ShowHashTable()
            if choice == "6":
                break
    if choice == "2":
        choice = input("Вставка таблиці хешуванням 1 - квадратичним, 2 - подвійним, 3 - linear")
        Hash = ClosedHashTable(m)
        if choice == "1":
            Hash.function = "quadratic"
        if choice == "2":
            Hash.function = "double"
        if choice == "3":
            Hash.function = "linear"

        while True:
            choice = input("1 - Вставка, 2 - Пошук, 3 - Видалення, 4 - змінити метод, 5 - показати, 6 - вихід\n")
            if choice == "1":
                x = int(input("Введіть елемент, який хочете вставити: "))
                print(Hash.HashInsert(x))
                Hash.ShowHashTable()
            if choice == "2":
                x = int(input("Введіть елемент, який хочете знайти: "))
                print(Hash.HashSearch(x))
                Hash.ShowHashTable()
            if choice == "3":
                x = int(input("Введіть елемент, який хочете видалити: "))
                Hash.HashDelete(x)
                Hash.ShowHashTable()
            if choice == "4":
                choice = input("1 - квадратичне, 2 - подвійне, 3 - лінійне")
                if choice == "1":
                    Hash.function = "quadratic"
                    print("Метод змінено на квадратичне")
                if choice == "2":
                    Hash.function = "double"
                    print("Метод змінено на подвійне")
                if choice == "3":
                    Hash.function = "linear"
                    print("Метод змінено на лінійне")
            if choice == "5":
                Hash.ShowHashTable()
            if choice == "6":
                break

    if choice == "3":
        break