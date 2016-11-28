package pr030405Barracks.core.commands;

public class FightCommand extends Command{

	public FightCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		return "fight";
	}
}
