import numpy as np
from tensorboardX import SummaryWriter

# Crear un SummaryWriter que escribirá los datos en 'runs/function_graph'
writer = SummaryWriter('runs/train1')

# Definir la función x = 2y + y^2 + y^3 + 3
def f(y):
    return 2*y + y**2 + y**3 + 3

# Crear un rango de valores para y
y_values = np.linspace(-2, 2, 400)

# Calcular los valores de x para cada valor de y
x_values = f(y_values)

# Escribir los datos en TensorBoard
for i, (y, x) in enumerate(zip(y_values, x_values)):
    writer.add_scalar('Función x = 2y + y^2 + y^3 + 3', x, i)

# Cerrar el writer
writer.close()
