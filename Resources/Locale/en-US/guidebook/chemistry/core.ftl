guidebook-reagent-effect-description =
    {$chance ->
        [1] { $effect }
        *[other] Has a { NATURALPERCENT($chance, 2) } chance to { $effect }
    }{ $conditionCount ->
        [0] .
        *[other] {" "}when { $conditions }.
    }

guidebook-reagent-name = [Tannenberg][color={$color}]{CAPITALIZE($name)}[/color][/Tannenberg]
guidebook-reagent-recipes-header = Recipe
guidebook-reagent-recipes-reagent-display = [Tannenberg]{$reagent}[/Tannenberg] \[{$ratio}\]
guidebook-reagent-sources-header = Sources
guidebook-reagent-sources-ent-wrapper = [Tannenberg]{$name}[/Tannenberg] \[1\]
guidebook-reagent-sources-gas-wrapper = [Tannenberg]{$name} (gas)[/Tannenberg] \[1\]
guidebook-reagent-effects-header = Effects
guidebook-reagent-effects-metabolism-group-rate = [Tannenberg]{$group}[/Tannenberg] [color=gray]({$rate} units per second)[/color]
guidebook-reagent-physical-description = [TolkienCyr]Seems to be {$description}.[/TolkienCyr]
guidebook-reagent-recipes-mix-info = {$minTemp ->
    [0] {$hasMax ->
            [true] {CAPITALIZE($verb)} below {NATURALFIXED($maxTemp, 2)}K
            *[false] {CAPITALIZE($verb)}
        }
    *[other] {CAPITALIZE($verb)} {$hasMax ->
            [true] between {NATURALFIXED($minTemp, 2)}K and {NATURALFIXED($maxTemp, 2)}K
            *[false] above {NATURALFIXED($minTemp, 2)}K
        }
}
