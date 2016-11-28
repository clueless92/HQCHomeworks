package pr030405Barracks.core.commands;

import pr030405Barracks.contracts.*;

public class RetireCommand extends Command {

	@Inject
	private Repository repository;

	public RetireCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		String unitType = this.getData()[1];
		this.repository.removeUnit(unitType);
		return unitType + " retired!";
	}
}
