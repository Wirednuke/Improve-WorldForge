using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;

namespace Kesmai.Server.Items;

public class Greatsword : Sword
{
	/// <inheritdoc />
	public override int LabelNumber => 6000045;

	/// <inheritdoc />
	public override uint BasePrice => 40;

	/// <inheritdoc />
	public override int Weight => 4350;

	/// <inheritdoc />
	public override int Category => 1;

	/// <inheritdoc />
	public override int MinimumDamage => 2;

	/// <inheritdoc />
	public override int MaximumDamage => 10;

	/// <inheritdoc />
	public override int BaseArmorBonus => 1;

	/// <inheritdoc />
	public override Skill Skill => Skill.Greatsword;

	/// <inheritdoc />
	public override WeaponFlags Flags => WeaponFlags.TwoHanded | WeaponFlags.Slashing;
		
	/// <summary>
	/// Initializes a new instance of the <see cref="Greatsword"/> class.
	/// </summary>
	public Greatsword() : base(98)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Greatsword"/> class.
	/// </summary>
	public Greatsword(int itemId) : base(itemId)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Greatsword"/> class.
	/// </summary>
	public Greatsword(Serial serial) : base(serial)
	{
	}

	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200019)); /* [You are looking at] [a large iron greatsword.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250018)); /* The iron greatsword appears quite ordinary. */
	}

	/// <inheritdoc />
	public override void Serialize(SpanWriter writer)
	{
		base.Serialize(writer);

		writer.Write((short)1); /* version */
	}

	/// <inheritdoc />
	public override void Deserialize(ref SpanReader reader)
	{
		base.Deserialize(ref reader);

		var version = reader.ReadInt16();

		switch (version)
		{
			case 1:
			{
				break;
			}
		}
	}
}