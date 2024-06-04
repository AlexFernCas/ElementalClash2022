import numpy as np
from tensorboardX import SummaryWriter

# Crear un SummaryWriter que escribirá los datos en 'runs/reward_curve_realistic'
writer = SummaryWriter('runs/reward_curve_realistic')

# Número de pasos
num_steps = 2000000

# Generar datos de recompensa suave
reward_values = np.zeros(num_steps)

# Generar una serie con fluctuaciones suaves
noise = np.random.normal(loc=0, scale=0.05, size=num_steps)

# Anotar un punto: +1 punto
for step in range(0, num_steps, 1000):
    reward_values[step] += 1

# Recibir un punto: -0.5 puntos
for step in range(500, num_steps, 1000):
    reward_values[step] -= 0.5

# Cada segundo de juego: +0.001
for step in range(num_steps):
    reward_values[step] += 0.001

# Usar los avances: +0.15
for step in range(5000, num_steps, 5000):
    reward_values[step] += 0.15

# Escribir los datos de recompensa en TensorBoard
for step, reward in enumerate(reward_values):
    writer.add_scalar('Recompensa', reward, step)

# Cerrar el writer
writer.close()
