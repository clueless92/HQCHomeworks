package pr030405Barracks.core.commands;

import pr030405Barracks.contracts.*;

public abstract class Command implements Executable {

	private String[] data;

	protected Command(String[] data) {
		this.data = data;
	}

	protected String[] getData() {
		return data;
	}
}
