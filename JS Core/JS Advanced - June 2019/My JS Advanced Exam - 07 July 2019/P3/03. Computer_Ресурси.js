class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;

        this.totalRamMemory = ramMemory;
        this.totalCpuGHz = cpuGHz;

        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace) {
        var program = {
            name,
            requiredSpace
        }

        if (this.hddMemory < requiredSpace) {
            throw new Error("There is not enough space on the hard drive")
        }

        this.hddMemory -= requiredSpace;

        this.installedPrograms.push(program);

        return program;
    }

    uninstallAProgram(name) {
        var existiongProgram = this.installedPrograms.filter(x => x.name == name)[0];
        if (!existiongProgram) {
            throw new Error("Control panel is not responding");
        }

        this.hddMemory += existiongProgram.requiredSpace;

        var ind = this.installedPrograms.indexOf(existiongProgram);

        this.installedPrograms.splice(ind, 1);

        return this.installedPrograms;
    }

    openAProgram(name) {

        var existiongProgram = this.installedPrograms.filter(x => x.name == name)[0];
        if (!existiongProgram) {
            throw new Error(`The ${name} is not recognized`);
            return;
        }

        if (this.taskManager.some(x=> x.name === name)) /// check in the task manager if it is open
        {
            throw new Error(`The ${name} is already open`);
            return;
        }

        var ramUsage = (existiongProgram.requiredSpace / this.ramMemory) * 1.5;
        var cpuUsage = ((existiongProgram.requiredSpace / this.cpuGHz) / 500) * 1.5;
        
        var totalRam = this.taskManager.map(x=> x.ramUsage).reduce((a,b)=> a+b, 0) + ramUsage;
        var totalCpu = this.taskManager.map(x => x.cpuUsage).reduce((a, b) => a + b, 0) + cpuUsage; 
        
        if (totalRam > 100) {
            throw new Error(`${name} caused out of memory exception`);
        }

        if (totalCpu > 100) {
            throw new Error(`${name} caused out of cpu exception`);
        }

        var obj = {
            name, 
            ramUsage,
            cpuUsage,
        };

        this.taskManager.push(obj);

        return obj;
    }

    taskManagerView() {
        if (this.taskManager.length == 0) {
            return "All running smooth so far";
        }
        var result = []; 

        for (const p of this.taskManager) {
            result.push(`Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.ramUsage.toFixed(0)}%`);
        }

        return result.join("\n");
    }
}

// let computer = new Computer(4096, 7.5, 250000);

// computer.installAProgram('Word', 7300);
// computer.installAProgram('Excel', 10240);
// computer.installAProgram('PowerPoint', 12288);
// computer.uninstallAProgram('Word');
// computer.installAProgram('Solitare', 1500);

// computer.openAProgram('Excel');
// computer.openAProgram('Solitare');

// console.log(computer.installedPrograms);
// console.log(('-').repeat(50)) // Separator
// console.log(computer.taskManager);

// let computer = new Computer(4096, 7.5, 250000);

// computer.installAProgram('Word', 7300);
// computer.installAProgram('Excel', 10240);
// computer.installAProgram('PowerPoint', 12288);
// computer.installAProgram('Solitare', 1500);

// computer.openAProgram('Word');
// computer.openAProgram('Excel');
// computer.openAProgram('PowerPoint');
// computer.openAProgram('Solitare');

// console.log(computer.taskManagerView());


