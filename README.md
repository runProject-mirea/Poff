# Poff
# Our runner project

# 1 - ФУНКЦИОНАЛЬНЫЕ ТРЕБОВАНИЯ 

# Показатель очков  
Должен:
  * Корректно отображать количество очков за пройденное игроком расстояние (очки начисляются автоматически при передвижении игрового персонажа)
  * Регулярно обновляться
  * Не занимать большую часть экрана

# Проведение пальцем по экрану (далее свайп)  
Должен вызывать одно из игровых действий игрового персонажа:
 - Прыжок
 - Короткий рывок
 - Пригнуться 

# Взаимодействия игрока с объектами
При столкновении с:
 - Объектом препятствия, завершается игровая сессия. Вызывается меню проигрыша (Game Over Menu).
 - Объектом моба (вражеского персонажа) аналогично, как при столкновении с препятствием.

# Стартовое меню (Главное меню, Start Menu)
Это главное меню, которое встречает игрока при открытии приложения. В стартовом меню находятся такие кнопки, как:
 - Start. При нажатии на Start, вызывается игровой уровень и начинается игра.
 - Game Settings. Появляется небольшое меню с двумя кнопками: Music - при нажатии включает/выключает музыку и Sound – при нажатии включает/выключает звуковые эффекты и музыку.

# Кнопка Pause 
Существует только пока активна игровая сессия. Вызывает меню паузы (Pause Menu).

# Меню паузы (Pause Menu)
Вызывается кнопкой Pause. В этом меню есть две кнопки:
 - Game Settings. Меню игровых настроек, работает аналогично такой же кнопке, как и Game Settings в главном меню.
 - Exit. При нажатии заканчивает игровую сессию и вызывает переход к главному меню.

# Меню окончания игры (Game Over Menu)
Меню вызывается при проигрыше. В нём выводятся показатель очков. 
В нём находятся две кнопки:
 - Restart. Начинает новую игровую сессию. Работает также, как кнопка Start из главного меню.
 - Exit. Вызывает переход к главному меню.
 

# 2 - ИНСТРУКЦИЯ ПО СБОРКЕ ПРОЕКТА 
 1 - Перейти в меню File( В левом верхнем углу) 
 2 - Выбрать пункт Build settings 
 3 - Далее в меню Build settings ( выбираем пункт Scenes in build) выбирем нужные сцены 
 4 - Нажимаем на build и выбираем директорию установки 
 Теперь в папке появляется лаунчер с игрой и локальными файлами 

# 3 - ИНСТРУКЦИЯ ДЛЯ ПОЛЬЗОВАТЕЛЕЙ 
Игра содержит 3 сцены Главное меню, Игровую сцену, Меню конца игры 
 1 - При старте игры появляется начальное меню, оно содержит 2 кнопки
  * Start - Начинает игру 
  * Exit - Выходит из игры 
 2 - Далее после чего, мы можем выбрать Start, начнется игра
  * Управление осуществляется 2 кнопками 
   - 1 d - Данная кнопка отвечает за ускорение(телепортацию) после нажатия, игрок перемещается сквозь все обьекты на карте
   - 2 пробел - Данная кнопка отвечает за прыжок(в игре реализован двойной прыжок, после нажатия пробела есть возможность нажать его еще раз без отталкивания от платформ)
 3 - В случае если мы умираем появляется меню смерти 
  * Меню содержит 3 кнопки 
   - 1 Restart - Начинает уровень сначала 
   - 2 Menu - Переходит в сцену с меню
   - 3 Exit - Выходит из игры 

