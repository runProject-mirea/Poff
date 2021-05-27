# Poff
# Маленький кружок бежит вперед, у него есть только 10 секунд, чтобы съесть спасительный лед или пасть в бездну. 
***

# 1 - ДЛЯ ПОЛЬЗОВАТЕЛЕЙ 
Игра содержит 3 сцены Главное меню, Игровую сцену, Меню конца игры 
  ---
 **При старте игры появляется начальное меню, оно содержит 2 кнопки**
  * Start - Начинает игру 
  * Exit - Выходит из игры 
   ---
 Далее после чего, мы можем выбрать Start, начнется игра
  * Управление осуществляется 2 кнопками 
   - 1 (d) - Данная кнопка отвечает за ускорение(телепортацию) после нажатия, игрок перемещается сквозь все обьекты на карте
   - 2 (пробел) - Данная кнопка отвечает за прыжок(в игре реализован двойной прыжок, после нажатия пробела есть возможность нажать его еще раз без отталкивания от платформ)
   ---
 В случае если мы умираем появляется меню смерти 
  * Меню содержит 3 кнопки 
   - 1 Restart - Начинает уровень сначала 
   - 2 Menu - Переходит в сцену с меню
   - 3 Exit - Выходит из игры 
***

# 2 - ФУНКЦИОНАЛ

# Показатель очков  
Должен:
  * Корректно отображаtn количество очков за пройденное игроком расстояние (очки начисляются автоматически при передвижении игрового персонажа)
  * Регулярно обновляется
  * Не занимает большую часть экрана

# Кнопки d и пробел (Клавиатура)  
Должен вызывать одно из игровых действий игрового персонажа:
 - Прыжок - пробел
 - Короткий рывок - d

# Взаимодействия игрока с объектами
При столкновении с:
 - Объектом (Кубик льда) , Заряжает рывок и добавляет очки.

# Стартовое меню (Главное меню, Start Menu)
Это главное меню, которое встречает игрока при открытии приложения. В стартовом меню находятся такие кнопки, как:
 - Start. При нажатии на Start, вызывается игровой уровень и начинается игра.

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
***
 

# 3 - ИНСТРУКЦИЯ ПО СБОРКЕ ПРОЕКТА 
 1 - Перейти в меню File( В левом верхнем углу) 
 ---
 2 - Выбрать пункт Build settings 
 ---
 3 - Далее в меню Build settings ( выбираем пункт Scenes in build) выбирем нужные сцены 
 ---
 4 - Нажимаем на build и выбираем директорию установки 
 ---
 Теперь в папке появляется лаунчер с игрой и локальными файлами 
 ***
