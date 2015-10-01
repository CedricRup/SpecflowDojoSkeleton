# But de l'exercice

Il s'agit d'implémenter les premières fonctionnalités d'un jeu.

Pour vous aider, des tests issus de scénarios construits en Behaviour Driven Developement vous sont fournis.
L'exercice a pour but de montrer la relation entre BDD et TDD : pour pouvoir écrite du code de production, il vous faut un test unitaire en échec pour définir le comportement attendu !

# Prérequis

-	Connaitre TDD
- 	Avoir installé l'extension Specflow pour Visual Studio
- 	Une connaissance de Web API est un plus 

# L'histoire

Votre Product Owner vient vous voir de bon matin : visiblement, la soirée a été brumeuse mais créatrice ! Il a plein d'idées pour le nouveau jeu que vous êtes en train de développer.

Il vous sort le coin de nappe sur lequel il a noté tout ça et s'enfuit prendre un café. Vous parvenez à déchiffrer :


	Le but est de réaliser un rituel avant son échéance
	Un rituel est composé d’actions

	Une action met un nombre de jours à être réalisée

	- Un villageois fait une chose par jour
	- Accomplir une action du rituel
	- Travailler pour gagner de l’argent
	- Acquérir une compétence
	
	Une fois qu’un villageois travaille sur une action, il doit la terminer avant de passer à autre chose
	
	Une action bien réalisée amène un point de ferveur
	
	Certaines actions ne peuvent être réalisées qu’avec la compétence nécessaire
	- Construire un temple -> architecture
	- Invoquer un rongeur démoniaque -> Magie Noire 
	
	Les villageois peuvent dépenser de l’argent pour acquérir une compétence ou des objets
	
	A la fin de la journée, le Crocto mange le développeur ayant le moins de point de ferveur
	
	La partie se termine s'il n’y a plus de villageois ou si le rituel est accompli ;o)


Pas très clair tout ça... heureusement, l'équipe a mis en place la pratique du Behaviour Driven Development. Ca consiste a avoir une discussion concentr&e sur des exemples avec les différents acteurs du projet afin de clarifier les choses.

L'équipe a trouvé bien des avantages dans cette pratique :

-	on evite les malentendus
- 	les exemples bien concrets permettent de mieux se représenter les différents cas... et d'en trouver de nouveaux !
- 	il est plus facile de repérer le scope creep, une fonctionnalité qui s'étale comme un vieux camembert parce qu'on ne sait pas ce qu'on veut faire au départ
- 	bonus : on a des données concrètes... qu'on peut transformer en tests !

Accompagné de votre collègue testeur, vous avez donc capturé votre Product Owner près de la cafetière, et vous vous êtes mis d'accord sur les premières fonctionnalités à implémenter.

Grâce à BDD, vous avez écarté les malentendus et cadré les règles... il est maintenant temps de coder !


# C'est parti !

Les exemples discutés avec le Product Owner ont été formalisés avec le langage Gherkin puisque vous avez décidé d'utiliser Specflow (Cucumber pour .NET !)
Votre méthodologie consiste à faire passer les tests Specflow au vert... sachant que tout code de production écrit doit l'être en TDD !
Vous avez débuté l'implémentation, il faut maintenant poursuivre.

Clonez la repository et faites passer les différents tests. Ouvrez le fichier feature "Action" dans le projet Specs et regardez on vous en êtes !  

