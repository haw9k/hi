def f(x):

    return x**3 - 6 * x**2 + 11 * x - 6


def f_prime(x):

    return 3 * x**2 - 12 * x + 11  # Производная вычислена аналитически

# Метод Ньютона для нахождения одного корня
def newton_method(f, f_prime, x0, tol=1e-6, max_iter=100):

    x = x0  # Устанавливаю начальное приближение
    for _ in range(max_iter):
        fx = f(x)
        fpx = f_prime(x)
        if abs(fpx) < tol:  # Проверяю, чтобы производная не была слишком малой
            return None
        x_new = x - fx / fpx  # Формула метода Ньютона
        if abs(x_new - x) < tol:  # Проверяю сходимость по допустимой погрешности
            return x_new  # Если сходимость достигнута, возвращаю корень
        x = x_new  # Обновлю текущее приближение
    return None  # Если корень не найден за max_iter итераций

# Нахождение всех корней функции на заданном отрезке
def find_all_roots(f, f_prime, a, b, step=0.5, tol=1e-6):

    roots = []
    x = a
    while x <= b:
        root = newton_method(f, f_prime, x, tol=tol)
        if root is not None:
            # Проверяю, нет ли уже найденного близкого корня
            if all(abs(root - r) > tol for r in roots):
                roots.append(root)  # Добавляем корень в список, если он уникален
        x += step
    return sorted(roots)


with open("input.txt", "r") as infile:
    lines = infile.readlines()
    a, b = map(float, lines[0].split())

# Нахождение всех корней на отрезке [a, b]
roots = find_all_roots(f, f_prime, a, b)


with open("output.txt", "w") as outfile:
    for root in roots:
        outfile.write(f"{root:.6f}\n")

0 4
1 2 3
