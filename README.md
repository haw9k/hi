import math

# Чтение данных из файла
def read_input(filename):
    with open(filename, 'r') as f:
        # Считываем список x
        x = list(map(float, f.readline().split()))
        # Считываем список y
        y = list(map(float, f.readline().split()))
        # Считываем xmin и xmax
        xmin, xmax = map(float, f.readline().split())
    return x, y, xmin, xmax

# Функция для вычисления суммы
def sum_values(values):
    total = 0
    for v in values:
        total += v
    return total

# Функция для вычисления тригонометрической интерполяции
def trig_interpolation(x, y, N):
    M = len(x)
    # Нулевой коэффициент a0 (среднее значение y)
    a0 = sum_values(y) / M

    a = []
    b = []
    
    for n in range(1, N + 1):
        an_sum = 0
        bn_sum = 0
        for i in range(M):
            angle = 2 * math.pi * n * x[i] / (x[-1] - x[0])
            an_sum += y[i] * math.cos(angle)
            bn_sum += y[i] * math.sin(angle)
        
        # Коэффициенты an и bn
        an = 2 * an_sum / M
        bn = 2 * bn_sum / M
        
        a.append(an)
        b.append(bn)
    
    return a0, a, b

# Функция для записи результатов в файл
def write_output(filename, xmin, xmax, a0, a, b):
    with open(filename, 'w') as f:
        f.write(f'xmin: {xmin}, xmax: {xmax}\n')
        f.write(f'a0: {a0}\n')
        f.write(f'a coefficients: {a}\n')
        f.write(f'b coefficients: {b}\n')

# Программа выполняется сразу после запуска

# Считываем данные из файла input.txt
x, y, xmin, xmax = read_input('input.txt')

# Количество нечетных полиномов для интерполяции
N = 5  # Количество гармоник для тригонометрической интерполяции

# Выполняем тригонометрическую интерполяцию
a0, a, b = trig_interpolation(x, y, N)

# Записываем результаты в файл output.txt
write_output('output.txt', xmin, xmax, a0, a, b)

