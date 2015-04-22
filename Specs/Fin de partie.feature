Fonctionnalité: Fin de partie
	
Scénario: La partie est gagnée si il n'y a plus de story avant la date de release

	Etant donné le projet 'Crocto' avec les stories suivantes
	| Titre                | Charge |
	| Souscrire un contrat | 1      |
	Et la date de démarrage du projet 'Crocto' est au 17/08/2014
	Et la date de release du projet 'Crocto' est au 17/08/2015

	Et l'équipe 'A-Team' est constituée de 
	| Nom   |
	| Alice |

	Et l'équipe 'A-Team' travaille sur le projet 'Crocto'
	
	Etant donné que 'Alice' travaille sur 'Souscrire un contrat'
	
	Quand la journée se termine
	Alors le projet est terminé


Scénario: La partie est perdue si il reste de la charge le jour de la date de release

	Etant donné le projet 'Crocto' avec les stories suivantes
	| Titre             | Charge |
	| Souscrire un contrat |     2  |
	Et la date de démarrage du projet 'Crocto' est au 16/08/2015
	Et la date de release du projet 'Crocto' est au 17/08/2015

	Et l'équipe 'A-Team' est constituée de 
	| Nom   |
	| Alice |

	Et l'équipe 'A-Team' travaille sur le projet 'Crocto'
	
	Etant donné que 'Alice' travaille sur 'Souscrire un contrat'
	
	Quand la journée se termine
	Alors le projet est en retard
