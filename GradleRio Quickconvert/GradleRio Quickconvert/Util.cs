﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradleRio_Quickconvert
{
    class Util
    {
        public const int TeamNumberIndex = 7;
        public const int RobotClassIndex = 8;
        public const int RobotLibIndex = 42;

        public static string[] buildGradleArray = new string[]
        {
            "plugins {",
            "    id \"java\"",
            "    id \"eclipse\"",
            "    id \"idea\"",
            "    id \"jaci.openrio.gradle.GradleRIO\" version \"2018.03.06\"",
            "}",
            "",
            "def TEAM = ",
            "def ROBOT_CLASS = \"",
            "",
            "// Define my targets (RoboRIO) and artifacts (deployable files)",
            "// This is added by GradleRIO's backing project EmbeddedTools.",
            "deploy {",
            "    targets {",
            "        target(\"roborio\", jaci.openrio.gradle.frc.RoboRIO) {",
            "            team = TEAM",
            "        }",
            "    }",
            "    artifacts {",
            "        artifact('frcJava', jaci.openrio.gradle.frc.FRCJavaArtifact) {",
            "            targets << \"roborio\"",
            "        }",
            "   }",
            "}",
            "",
            "// Setup eclipse classpath settings, so the javadoc and sources are available in eclipse",
            "eclipse {",
            "    classpath{",
            "        downloadJavadoc = true",
            "        downloadSources = true",
            "    }",
            "}",
            "",
            "repositories {",
            "	maven { url 'https://jitpack.io' }",
            "}",
            "",
            "// Defining my dependencies. In this case, WPILib (+ friends), CTRE Phoenix (Talon SRX), NavX, and ORF's RobotLib.",
            "dependencies {",
            "    compile wpilib()",
            "    compile ctre()",
            "    compile navx()",
            "    compile \"com.github.MoSadie:RobotLib:e0501b7aa8\"",
            "}",
            "",
            "// Setting up my Jar File. In this case, adding all libraries into the main jar ('fat jar')",
            "// in order to make them all available at runtime. Also adding the manifest so WPILib",
            "// knows where to look for our Robot Class.",
            "jar {",
            "    from configurations.compile.collect { it.isDirectory() ? it : zipTree(it) }",
            "        manifest jaci.openrio.gradle.GradleRIOPlugin.javaManifest(ROBOT_CLASS)",
            "}",
            "",
            "task wrapper(type: Wrapper) {",
            "    gradleVersion = '4.4'",
            "}"
        };
    }
}
