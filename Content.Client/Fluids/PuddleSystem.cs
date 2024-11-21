using Content.Client.IconSmoothing;
using Content.Shared.Chemistry.Components;
using Content.Shared.Fluids;
using Content.Shared.Fluids.Components;
using Robust.Client.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Maths; // Everwood
using Robust.Shared.Random; // Everwood

namespace Content.Client.Fluids;

public sealed class PuddleSystem : SharedPuddleSystem
{
    [Dependency] private readonly IconSmoothSystem _smooth = default!;
    [Dependency] private readonly IRobustRandom _random = default!; // Everwood

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PuddleComponent, AppearanceChangeEvent>(OnPuddleAppearance);
    }

    private void OnPuddleAppearance(EntityUid uid, PuddleComponent component, ref AppearanceChangeEvent args)
    {
        if (args.Sprite == null)
            return;
        /* Everwood REMOVE | Legacy Puddle
        var volume = 1f;

        if (args.AppearanceData.TryGetValue(PuddleVisuals.CurrentVolume, out var volumeObj))
        {
            volume = (float) volumeObj;
        }
        */

        /* Everwood REMOVE | Legacy Puddle
        // Update smoothing and sprite based on volume.
        if (TryComp<IconSmoothComponent>(uid, out var smooth))
        {
            if (volume < LowThreshold)
            {
                args.Sprite.LayerSetState(0, $"{smooth.StateBase}a");
                _smooth.SetEnabled(uid, false, smooth);
            }
            else if (volume < MediumThreshold)
            {
                args.Sprite.LayerSetState(0, $"{smooth.StateBase}b");
                _smooth.SetEnabled(uid, false, smooth);
            }
            else
            {
                if (!smooth.Enabled)
                {
                    args.Sprite.LayerSetState(0, $"{smooth.StateBase}0");
                    _smooth.SetEnabled(uid, true, smooth);
                    _smooth.DirtyNeighbours(uid);
                }
            }
        }
        */

        // Everwood
        if (TryComp<SpriteComponent>(uid, out var sprite))
        {
            RandomizeRotation(sprite);
        }

        var baseColor = Color.White;

        if (args.AppearanceData.TryGetValue(PuddleVisuals.SolutionColor, out var colorObj))
        {
            var color = (Color) colorObj;
            args.Sprite.Color = color * baseColor;
        }
        else
        {
            args.Sprite.Color *= baseColor;
        }
    }

    #region Spill

    // Maybe someday we'll have clientside prediction for entity spawning, but not today.
    // Until then, these methods do nothing on the client.
    /// <inheritdoc/>
    public override bool TrySplashSpillAt(EntityUid uid, EntityCoordinates coordinates, Solution solution, out EntityUid puddleUid, bool sound = true, EntityUid? user = null)
    {
        puddleUid = EntityUid.Invalid;
        return false;
    }

    /// <inheritdoc/>
    public override bool TrySpillAt(EntityCoordinates coordinates, Solution solution, out EntityUid puddleUid, bool sound = true)
    {
        puddleUid = EntityUid.Invalid;
        return false;
    }

    /// <inheritdoc/>
    public override bool TrySpillAt(EntityUid uid, Solution solution, out EntityUid puddleUid, bool sound = true, TransformComponent? transformComponent = null)
    {
        puddleUid = EntityUid.Invalid;
        return false;
    }

    /// <inheritdoc/>
    public override bool TrySpillAt(TileRef tileRef, Solution solution, out EntityUid puddleUid, bool sound = true, bool tileReact = true)
    {
        puddleUid = EntityUid.Invalid;
        return false;
    }

    #endregion Spill

    // Everwood Start
    private void RandomizeRotation(SpriteComponent sprite)
        {
            float rotationDegrees = _random.Next(0, 359); // Randomly select a rotation for puddle sprite.
            sprite.Rotation = Angle.FromDegrees(rotationDegrees); // Sets the sprite rotation to the one we randomly selected.
        }
    // Everwood End
}
