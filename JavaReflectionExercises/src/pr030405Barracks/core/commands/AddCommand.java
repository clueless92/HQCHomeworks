package pr030405Barracks.core.commands;

import pr030405Barracks.contracts.*;

public class AddCommand extends Command {

	@Inject
	private Repository repository;
	@Inject
	private UnitFactory unitFactory;

	public AddCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		String unitType = this.getData()[1];
		Unit unitToAdd = this.unitFactory.createUnit(unitType);
		this.repository.addUnit(unitToAdd);
		String output = unitType + " added!";
		return output;
	}
}
