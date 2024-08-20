# Beat 'Em Up
 Test Project
В этом проекте я в основном использовал паттерн MVC. Также я применял другие паттерны, такие как Visitor, Fabric, State Machine и Observer. Моя цель была создать прочную основу для архитектуры кода, чтобы в будущем можно было легко добавлять новые функции.

Я заметил, что благодаря паттерну MVC удалось достичь слабой связанности кода. Однако в некоторых местах я не до конца реализовал этот принцип, так как под конец работы немного устал. В будущем я планирую перейти от стандартного MVC, где контроллер не знает о view, к варианту, где контроллер осведомлён о view. Это позволит избежать необходимости использовать костыли для запуска анимации, как это было в случае с TastViewUnit.

К сожалению, я не обобщил контроллеры, хотя планировал. Я думал, что их реализация будет сильно отличаться, но в итоге они оказались довольно похожими. То же самое можно сказать и о фабриках.

Фабрики я реализовал не очень гибко, и это меня не устраивает. В коде есть некоторые орфографические ошибки в комментариях, за что я прошу прощения. Также у меня может быть плохой выбор имён для полей, но я знаю правила нейминга и просто немного торопился.

Также я создал свой  джойстик(довольно кривой). Я не хотел нарушать инструкции, поэтому не использовал  ассет для джойстика.

Благодаря некоторым аспектам я могу довольно быстро реализовать определённые функции. Например, после смерти игрока я могу позволить ему играть за бота, просто заменив контроллер (правда, нужно будет что-то сделать с move, но это не сложно).

Также я могу удобно включать различные анимации при разных взаимодействиях благодаря паттерну Visitor. И я могу легко заменить управление с мобильного на ПК, так как input у меня — это лишь абстракция. Кроме того, я могу заменить способ передвижения,например на rigidbody.

Эта архитектура открывает множество возможностей, но, возможно, она слишком сложна для такой игры.

PS:Я доволен своей работой, но не доконца. начало было отличным, а в конце мне не удалось дожать.


