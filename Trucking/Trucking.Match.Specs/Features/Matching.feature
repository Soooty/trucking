Feature: Matching

Scenario: One compatible vehicle with one job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A                    |

	And the jobs
		| Id | Type |
		| 1  | A    |

	When we match the jobs with the vehicles
	
	Then following pairs will be fount
		| Job id | Vehicle id |
		| 1      | 1          |