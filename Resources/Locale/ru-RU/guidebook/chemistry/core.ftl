guidebook-reagent-effect-description =
    { $chance ->
        [1] { $effect }
       *[other] Имеет { NATURALPERCENT($chance, 2) } шанс на { $effect }
    }{ $conditionCount ->
        [0] .
       *[other] { " " }когда { $conditions }.
    }

guidebook-reagent-name = [Tannenberg][color={ $color }]{ CAPITALIZE($name) }[/color][/Tannenberg]
guidebook-reagent-recipes-header = Рецепт
guidebook-reagent-recipes-reagent-display = [Tannenberg]{ $reagent }[/Tannenberg] \[{ $ratio }\]
guidebook-reagent-sources-header = Источники
guidebook-reagent-sources-ent-wrapper = [Tannenberg]{$name}[/Tannenberg] \[1\]
guidebook-reagent-sources-gas-wrapper = [Tannenberg]{$name} (газ)[/Tannenberg] \[1\]
guidebook-reagent-effects-header = Эффекты
guidebook-reagent-effects-metabolism-group-rate = [Tannenberg]{ $group }[/Tannenberg] [color=gray]({ $rate } единиц в секунду)[/color]
guidebook-reagent-physical-description = [TolkienCyr]Кажется {$description}.[/TolkienCyr]
guidebook-reagent-recipes-mix-info = {$minTemp ->
    [0] {$hasMax ->
            [true] {CAPITALIZE($verb)} ниже {NATURALFIXED($maxTemp, 2)}K
            *[false] {CAPITALIZE($verb)}
        }
    *[other] {CAPITALIZE($verb)} {$hasMax ->
            [true] между {NATURALFIXED($minTemp, 2)}K и {NATURALFIXED($maxTemp, 2)}K
            *[false] выше {NATURALFIXED($minTemp, 2)}K
        }
}

