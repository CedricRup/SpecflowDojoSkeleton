Fonctionnalité: Travailler sur une action

@US001
Scénario: Quand un villageois travaille sur une action, la charge de travail restante sur l'action diminue

	Etant donné le rituel 'Crocto' avec les actions suivantes
	| Intitule            | Charge |
	| Chasser un éléphant | 2      |
		
	Et le village 'Petibonum' habité par
	| Nom   |
	| Alice |

	Et le village 'Petibonum' effectue le rituel 'Crocto'

	Etant donné le plan d'action pour le rituel 'Crocto'
	| Villageois | Action              |
	| Alice      | Chasser un éléphant |

	Quand la journée se termine
	Alors les actions pour le rituel 'Crocto' sont dans l'état suivant
	| Intitule            | Charge |
	| Chasser un éléphant | 1      |
	

	

@US001
Scénario: Quand personne ne travaille sur une action, la charge de travail restante sur l'action ne diminue pas

	Etant donné le rituel 'Crocto' avec les actions suivantes
	| Intitule            | Charge |
	| Chasser un éléphant | 2      |
		
	Et le village 'Petibonum' habité par
	| Nom   |
	| Alice |

	Et le village 'Petibonum' effectue le rituel 'Crocto'

	Etant donné le plan d'action pour le rituel 'Crocto'
	| Villageois | Action              |

	Quand la journée se termine
	Alors les actions pour le rituel 'Crocto' sont dans l'état suivant
	| Intitule            | Charge |
	| Chasser un éléphant | 2      |


@US001
Scénario: Une action est terminée lorsque sa charge atteint 0

	Etant donné le rituel 'Crocto' avec les actions suivantes
	| Intitule            | Charge |
	| Chasser un éléphant | 2      |
	| Invoquer un orage   | 1      |
		
	Et le village 'Petibonum' habité par
	| Nom   |
	| Alice |

	Et le village 'Petibonum' effectue le rituel 'Crocto'

	Etant donné le plan d'action pour le rituel 'Crocto'
	| Villageois | Action            |
	| Alice      | Invoquer un orage |

	Quand la journée se termine
	Alors les actions pour le rituel 'Crocto' sont dans l'état suivant
	| Intitule            | Charge |
	| Chasser un éléphant | 2      |


	   