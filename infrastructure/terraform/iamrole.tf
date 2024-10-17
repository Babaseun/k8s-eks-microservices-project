# resource "aws_iam_role" "eks_worker_node_role" {
#   name = "eks_worker_node_role"

#   assume_role_policy = data.aws_iam_policy_document.eks_assume_role_policy.json
# }

# data "aws_iam_policy_document" "eks_assume_role_policy" {
#   statement {
#     actions = ["sts:AssumeRole"]

#     principals {
#       type        = "Service"
#       identifiers = ["ec2.amazonaws.com"]
#     }
#   }
# }

# # AmazonEKSWorkerNodePolicy
# resource "aws_iam_role_policy" "eks_worker_node_policy" {
#   name = "AmazonEKSWorkerNodePolicy"
#   role = aws_iam_role.eks_worker_node_role.id

#   policy = jsonencode({
#     Version = "2012-10-17"
#     Statement = [
#       {
#         Effect   = "Allow"
#         Action   = [
#           "ec2:DescribeInstances",
#           "ec2:DescribeTags",
#           "autoscaling:DescribeAutoScalingGroups",
#           "autoscaling:DescribeAutoScalingInstances",
#           "autoscaling:DescribeTags"
#         ]
#         Resource = "*"
#       }
#     ]
#   })
# }

# # AmazonEKS_CNI_Policy
# resource "aws_iam_role_policy" "eks_cni_policy" {
#   name = "AmazonEKS_CNI_Policy"
#   role = aws_iam_role.eks_worker_node_role.id

#   policy = jsonencode({
#     Version = "2012-10-17"
#     Statement = [
#       {
#         Effect   = "Allow"
#         Action   = [
#           "ec2:AssignPrivateIpAddresses",
#           "ec2:UnassignPrivateIpAddresses",
#           "ec2:DescribeInstances",
#           "ec2:DescribeTags",
#           "ec2:CreateTags",
#           "ec2:DeleteTags"
#         ]
#         Resource = "*"
#       }
#     ]
#   })
# }

# # AmazonEC2ContainerRegistryReadOnly
# resource "aws_iam_role_policy" "ec2_container_registry_read_only_policy" {
#   name = "AmazonEC2ContainerRegistryReadOnlyPolicy"
#   role = aws_iam_role.eks_worker_node_role.id

#   policy = jsonencode({
#     Version = "2012-10-17"
#     Statement = [
#       {
#         Effect   = "Allow"
#         Action   = [
#           "ecr:GetDownloadUrlForLayer",
#           "ecr:BatchGetImage",
#           "ecr:BatchCheckLayerAvailability"
#         ]
#         Resource = "*"
#       }
#     ]
#   })
# }
